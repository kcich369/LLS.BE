using FluentValidation;
using LLS.Database.IdentityModels;
using LLS.Domain.Commands;
using LLS.Domain.Dtos;
using LLS.Domain.Enumerations;
using LLS.Domain.Enumerations.ApiResponseEnumeration;
using LLS.Domain.Interfaces;
using LLS.Domain.Results;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace LLS.Infrastructure.Services;

public sealed class UserRegistrationService(
    UserManager<User> userManager,
    IValidator<RegisterUser> validator)
    : IUserRegistrationService
{
    public async Task<IResult<UserCreatedDto>> Reqister(RegisterUser usrData)
    {
        var validation = await validator.ValidateAsync(usrData);
        if (!validation.IsValid)
            return Result<UserCreatedDto>.Error(UserAuthApiResTypesEnumerations.InvalidUserData,
                string.Join(';', validation.Errors.Select(x => $"{x.PropertyName}: {x.ErrorMessage}")));
        var userEmail = await userManager.FindByEmailAsync(usrData.Email);
        if (userEmail is not null)
            return Result<UserCreatedDto>.Error(UserAuthApiResTypesEnumerations.EmailExists);
        var userLogin = await userManager.FindByNameAsync(usrData.UserName);
        if (userLogin is not null)
            return Result<UserCreatedDto>.Error(UserAuthApiResTypesEnumerations.LoginExists);
        var userPhoneNumber = await userManager.Users.FirstOrDefaultAsync(u => u.PhoneNumber == usrData.PhoneNumber);
        if (userPhoneNumber is not null)
            return Result<UserCreatedDto>.Error(UserAuthApiResTypesEnumerations.PhoneNumberExists);

        var user = User.Create(usrData.UserName, usrData.Email, usrData.PhoneNumber, usrData.Name, usrData.Surname,
            new Address(usrData.Street, usrData.BuildingNumber, usrData.City, usrData.Voivodeship,
                usrData.Country, usrData.ZipCode));
        var registrationResult = await userManager.CreateAsync(user, usrData.Password);
        if (!registrationResult.Succeeded)
            return Result<UserCreatedDto>.Error(UserAuthApiResTypesEnumerations.InvalidUserData,
                string.Join(';', registrationResult.Errors.Select(x => $"{x.Code}: {x.Description}")));
        await userManager.AddToRoleAsync(user, RoleEnum.User);
        return Result<UserCreatedDto>.Success(new UserCreatedDto() { Id = user.Id });
    }
}