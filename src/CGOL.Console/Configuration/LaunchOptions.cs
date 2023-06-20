using CommandLine;

namespace CGOL.Console.Configuration;

public record LaunchOptions
{
    /// <summary>
    ///		The seed for the RNG.
    /// </summary>
    [Option('s', "seed", Required = false, HelpText = "The seed for the RNG.")]
    public string? Seed { get; init; }
}