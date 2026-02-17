using CapitolServicesTechnical.Services;
using Xunit;

namespace CapitolServicesTechnical.Tests;

public class FizzBuzzServiceTests
{
    [Fact]
    public void Returns100Lines()
    {
        // We aren't ACTUALLY leveraging the repo, so we don't need to instantiate it, so that's why we
        // have a null! as the parameter.
        var service = new FizzBuzzService(null!);
        var result = service.FizzBuzz();
        var lines = result.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

        Assert.Equal(100, lines.Length);
    }

    [Fact]
    public void ReturnsNumbersNotDivisibleByThreeOrFive()
    {
        var service = new FizzBuzzService(null!);
        var result = service.FizzBuzz();
        var lines = result.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

        Assert.Equal("1", lines[0]);
        Assert.Equal("2", lines[1]);
        Assert.Equal("7", lines[6]);
    }

    [Fact]
    public void ReturnsFizzForMultiplesOfThree()
    {
        var service = new FizzBuzzService(null!);
        var result = service.FizzBuzz();
        var lines = result.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

        Assert.Equal("Fizz", lines[2]);
        Assert.Equal("Fizz", lines[5]);
    }

    [Fact]
    public void ReturnsBuzzForMultiplesOfFive()
    {
        var service = new FizzBuzzService(null!);
        var result = service.FizzBuzz();
        var lines = result.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

        Assert.Equal("Buzz", lines[4]);
        Assert.Equal("Buzz", lines[9]);
    }

    [Fact]
    public void ReturnsFizzBuzzForMultiplesOfFifteen()
    {
        var service = new FizzBuzzService(null!);
        var result = service.FizzBuzz();
        var lines = result.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

        Assert.Equal("FizzBuzz", lines[14]);
        Assert.Equal("FizzBuzz", lines[29]);
    }
}