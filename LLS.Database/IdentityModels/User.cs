using LLS.Domain.Dtos;
using Microsoft.AspNetCore.Identity;

namespace LLS.Database.IdentityModels;

public sealed class User : IdentityUser
{
    public string Name { get; private set; }

    public string Surname { get; private set; }
    
    public bool Active { get; private set; }

    public DateTimeOffset CreatedAt { get; private set; }
    public DateTimeOffset UpdatedAt { get; private set; }

    public Address Address { get; private set; }


    public User()
    {
    }

    private User(string userName, string email, string phoneNumber, string name, string surname,
        Address address) : base()
    {
        UserName = userName;
        Email = email;
        PhoneNumber = phoneNumber;
        Name = name;
        Surname = surname;
        Address = address;
        CreatedAt = DateTimeOffset.Now;
    }

    public static User Create(string userName, string email, string phoneNumber, string name, string surname,
        Address address) =>
        new User(userName, email, phoneNumber, name, surname, address);

    public UserData ToUserData() => new()
        { Id = Id, UserName = UserName, Email = Email, PhoneNumber = PhoneNumber };

    public User Confirmed()
    {
        Active = true;
        EmailConfirmed = true;
        PhoneNumberConfirmed = true;
        return this;
    }
}