namespace LLS.Domain.Enumerations;

public sealed class RoleEnum
{
    public int Id { get; private set; }
    public string Name { get; private set; }

    public static RoleEnum Admin = new RoleEnum(0, "Admin");
    public static RoleEnum User = new RoleEnum(1, "User");
    
    public static RoleEnum[] All = new RoleEnum[] { Admin, User };
    public static string[] AllNames = All.Select(x => x.Name).ToArray();

    private RoleEnum(int id, string name)
    {
        Id = id;
        Name = name;
    }

    public static implicit operator string(RoleEnum rE) => rE.Name;
    public static implicit operator int(RoleEnum rE) => rE.Id;
}