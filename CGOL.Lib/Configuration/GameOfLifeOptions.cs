using CGOL.Lib.Constants;

namespace CGOL.Lib.Configuration;

public record GameOfLifeOptions
{
    /// <summary>
    ///		The height of the game area.
    /// </summary>
    public int Height { get; set; } = DefaultGameOfLifeOptions.DefaultHeight;

    /// <summary>
    ///		The width of the game area.
    /// </summary>
    public int Width { get; set; } = DefaultGameOfLifeOptions.DefaultWidth;

    /// <summary>
    ///		The seed for the RNG.
    /// </summary>
    public string? Seed { get; set; }

    /// <summary>
    ///		The speed with which the game runs.
    /// </summary>
    public int Speed { get; set; } = DefaultGameOfLifeOptions.DefaultSpeed;
};