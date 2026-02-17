using System.Text;
using CapitolServicesTechnical.Infrastructure.Interfaces;
using CapitolServicesTechnical.Services.Interfaces;

namespace CapitolServicesTechnical.Services;

public class FizzBuzzService : IFizzBuzzService
{
    private readonly IFizzBuzzRepository _repository;

    public FizzBuzzService(IFizzBuzzRepository repository)
    {
        _repository = repository;
    }

    public string FizzBuzz()
    {
        var output = new StringBuilder();
        
        for (int i = 1; i <= 100; i++)
        {
            if (i % 15 == 0)
            {
                // The requirement says to "Print" it, which would ordinarily be a Console.WriteLine(),
                // but I hope you don't mind me including the code as part of a service used by an MVC
                // controller class - as such, using string builder makes sense here :)
                output.AppendLine("FizzBuzz");
            }
            
            else if (i % 3 == 0)
            {
                output.AppendLine("Fizz");
            }

            else if (i % 5 == 0)
            {
                output.AppendLine("Buzz");
            }

            else
            {
                output.AppendLine(i.ToString());
            }
        }

        return output.ToString();
    }

    public async Task SaveToDatabaseAsync()
    {
        var results = FizzBuzz();
        var lines = results.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
        
        await _repository.SaveResultsAsync(lines);
    }
}
