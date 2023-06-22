namespace CGOL.Console.Models;

public class NamedAction
{
    /// <summary>
    ///		The Action to execute.
    /// </summary>
    public Action Action { get; init; } = null!;

    /// <summary>
    ///		A descriptive name for the action.
    /// </summary>
    public string Name { get; init; } = null!;
}