using CGOL.Console.Attributes;

using CommandLine;

using System.ComponentModel.DataAnnotations;

namespace CGOL.Console.Configuration;

public record LaunchOptions
{
    /// <summary>
    ///		The height of the game area.
    /// </summary>
    [Option('h', "height", Default = 30, Required = true, HelpText = "The height of the game area."), ConsoleHeight(30)]
    public int Height { get; init; }

    /// <summary>
    ///		The width of the game area.
    /// </summary>
    [Option('w', "width", Default = 120, Required = true, HelpText = "The width of the game area."), ConsoleWidth(120)]
    public int Width { get; init; }

    /// <summary>
    ///		The seed for the RNG.
    /// </summary>
    [Option('s', "seed", Required = false, HelpText = "The seed for the RNG.")]
    public string? Seed { get; init; }

    /// <summary>
    ///     The speed with which the game runs.
    /// </summary>
    [Option("speed", Required = false, HelpText = "The speed, with which the game runs. Can be between 1 and 1000."), Range(1, 1000)]
    public int? Speed { get; init; }
}