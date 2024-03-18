namespace LLS.Domain.Dtos;

public class UserData
{
    public string Id { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public IList<string> Roles { get; set; }

    public UserData SetRole(IList<string> role)
    {
        Roles = role;
        return this;
    }
}