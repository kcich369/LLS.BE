namespace LLS.Domain.Commands;

public record RegisterUser(
    string Name,
    string Surname,
    string UserName,
    string Email,
    string PhoneNumber,
    string Password,
    string Street ,
    string BuildingNumber,
    string City,
    string Voivodeship,
    string Country,
    string ZipCode);