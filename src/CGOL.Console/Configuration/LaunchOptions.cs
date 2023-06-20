using CommandLine;

using System.ComponentModel.DataAnnotations;

namespace CGOL.Console.Configuration;

public record LaunchOptions
{
    /// <summary>
    ///		The height of the game area.
    /// </summary>
    [Range(30, short.MaxValue)]
    [Option('h', "height", Default = 30, Required = true, HelpText = "The height of the game area.")]
    public int FieldHeight { get; init; } = 30;

    /// <summary>
    ///		The width of the game area.
    /// </summary>
    [Range(120, short.MaxValue)]
    [Option('w', "width", Default = 120, Required = true, HelpText = "The width of the game area.")]
    public int FieldWidth { get; init; } = 120;

    /// <summary>
    ///		The seed for the RNG.
    /// </summary>
    [Option('s', "seed", Required = false, HelpText = "The seed for the RNG.")]
    public string? Seed { get; init; }
}