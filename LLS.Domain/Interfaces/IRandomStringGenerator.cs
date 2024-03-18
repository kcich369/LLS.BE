namespace LLS.Domain.Interfaces;

public interface IRandomStringGenerator
{
    string Generate(int length);
}