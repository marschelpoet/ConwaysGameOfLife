using CGOL.Console.Attributes;

using CommandLine;

namespace CGOL.Console.Configuration;

public record LaunchOptions
{
    /// <summary>
    ///		The height of the game area.
    /// </summary>
    [ConsoleHeight(30)]
    [Option('h', "height", Default = 30, Required = true, HelpText = "The height of the game area.")]
    public int Height { get; init; } = 30;

    /// <summary>
    ///		The width of the game area.
    /// </summary>
    [ConsoleWidth(120)]
    [Option('w', "width", Default = 120, Required = true, HelpText = "The width of the game area.")]
    public int Width { get; init; } = 120;

    /// <summary>
    ///		The seed for the RNG.
    /// </summary>
    [Option('s', "seed", Required = false, HelpText = "The seed for the RNG.")]
    public string? Seed { get; init; }
}