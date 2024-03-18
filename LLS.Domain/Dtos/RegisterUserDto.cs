namespace LLS.Domain.Dtos;

public sealed class RegisterUserDto
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string PhoneNumber { get; set; }
    public string Street { get; set; }
    public string BuildingNumber { get; set; }
    public string City { get; set; }
    public string Voivodeship { get; set; }
    public string Country { get; set; }
}