using LLS.Domain.Enumerations.Base;

namespace LLS.Domain.Enumerations.ApiResponseEnumeration;

public class UserAuthApiResTypesEnumerations : ApiResponseTypesEnumerations
{
    public static UserAuthApiResTypesEnumerations InvalidUserData =
        new UserAuthApiResTypesEnumerations(1, "Dane użytkownika podczas rejestracji są nieprawidłowe.",
            "Dane użytkownika podczas rejestracji są nieprawidłowe. Treść: {0}");

    public static UserAuthApiResTypesEnumerations InvalidLoginData =
        new UserAuthApiResTypesEnumerations(2, "Nieprawidłowe dane logowania");

    public static UserAuthApiResTypesEnumerations UserWithIdNotExists =
        new UserAuthApiResTypesEnumerations(3, "Użytkownik o podanym id nie istnieje.",
            "Użytkownik o podanym id: {0} nie istnieje.");

    public static UserAuthApiResTypesEnumerations InactiveToken =
        new UserAuthApiResTypesEnumerations(4, "Sesja logowania wygasła.");

    public static UserAuthApiResTypesEnumerations EmailExists =
        new UserAuthApiResTypesEnumerations(5, "Użytkownik o podanym adresie e-mail już istnieje.");

    public static UserAuthApiResTypesEnumerations LoginExists =
        new UserAuthApiResTypesEnumerations(6, "Użytkownik o podanym loginie już istnieje.");

    public static UserAuthApiResTypesEnumerations PhoneNumberExists =
        new UserAuthApiResTypesEnumerations(7, "Użytkownik o podanym numerze telefonu już istnieje.");
    
    public static UserAuthApiResTypesEnumerations UserConfirmationToken =
        new UserAuthApiResTypesEnumerations(8, "Klucz do potwierdzenia użytkownika jest nieprawidłowy");

    protected UserAuthApiResTypesEnumerations(
        int errorCode,
        string errorMessage,
        string errorMessagePattern = null) : base(1, "UserAuthentication", errorCode, errorMessage,
        StatusCodeEnumerations.BadRequest, errorMessagePattern)
    {
    }
}