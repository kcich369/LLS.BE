namespace LLS.Domain.Enumerations;

public class UserTokenEnum
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public string Provider { get; private set; }

    public static UserTokenEnum Registration = new UserTokenEnum(0, nameof(Registration));
    public static UserTokenEnum EmailConfirmation = new UserTokenEnum(1, nameof(EmailConfirmation));
    public static UserTokenEnum PhoneConfirmation = new UserTokenEnum(2, nameof(PhoneConfirmation));
    public static UserTokenEnum ResetPassword = new UserTokenEnum(3, nameof(ResetPassword));

    private UserTokenEnum(int id, string provider)
    {
        Id = id;
        Provider = provider;
        Name = $"{provider}Token";
    }

    public static implicit operator int(UserTokenEnum rE) => rE.Id;
    public static implicit operator string(UserTokenEnum rE) => rE.Name;
}