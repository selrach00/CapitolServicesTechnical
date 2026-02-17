namespace CapitolServicesTechnical.Infrastructure.Interfaces;

public interface IFizzBuzzRepository
{
    Task SaveResultsAsync(IEnumerable<string> results);
}
