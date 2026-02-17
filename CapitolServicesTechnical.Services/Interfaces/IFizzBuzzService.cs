namespace CapitolServicesTechnical.Services.Interfaces;

public interface IFizzBuzzService
{
    string FizzBuzz();
    Task SaveToDatabaseAsync();
}
