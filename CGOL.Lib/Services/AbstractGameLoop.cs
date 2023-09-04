namespace CGOL.Lib.Services;

public abstract class AbstractGameLoop : IGameLoop
{
    protected static bool Run = true;
    protected static bool PauseGame = false;

    public static readonly NamedAction ExitAction = new()
    {
        Action = () => { Run = false; },
        Name = "Exit"
    };

    public static readonly NamedAction PauseAction = new()
    {
        Action = () => { PauseGame = !PauseGame; },
        Name = "Pause"
    };

    /// <inheritdoc />
    public abstract void RunGame();

    /// <inheritdoc />
    public void Stop()
    {
        ExitAction.Action();
    }

    /// <inheritdoc />
    public void Pause()
    {
        PauseAction.Action();
    }
}