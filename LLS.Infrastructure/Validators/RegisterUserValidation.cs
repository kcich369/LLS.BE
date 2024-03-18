using FluentValidation;
using LLS.Domain.Commands;

namespace LLS.Infrastructure.Validators;

public sealed class RegisterUserValidation : AbstractValidator<RegisterUser>
{

    public RegisterUserValidation()
    {
    }
}