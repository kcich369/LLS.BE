namespace LLS.Database.IdentityModels;

public class Address
{
    public string Street { get; private set; }
    public string BuildingNumber { get; private set; }
    public string City { get; private set; }
    public string Voivodeship { get; private set; }
    public string Country { get; private set; }
    public string ZipCode { get; private set; }

    private Address()
    {
    }

    public Address(string street, string buildingNumber, string city, string voivodeship, string country,
        string zipCode)
    {
        Street = street;
        BuildingNumber = buildingNumber;
        City = city;
        Voivodeship = voivodeship;
        Country = country;
        ZipCode = zipCode;
    }
}