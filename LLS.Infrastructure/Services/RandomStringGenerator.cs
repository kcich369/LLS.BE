using LLS.Domain.Interfaces;

namespace LLS.Infrastructure.Services;

public class RandomStringGenerator : IRandomStringGenerator
{
    private const string Chars = "AaBbCcDdEeFfGgHhIiJjKkLlMmNnOoPpQqRrSsTtUuVvWwXxYyZz0123456789";

    public string Generate(int length)
    {
        var random = new Random();
        return new string(Enumerable.Range(1, length).Select(_ => Chars[random.Next(Chars.Length)]).ToArray());
    }
}