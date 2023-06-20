using Microsoft.Extensions.Options;

namespace CGOL.Console.Services;

public class GameLoop : IHostedService
{
    private readonly Task _completedTask = Task.CompletedTask;
    private readonly LaunchOptions _launchOptions;

    public GameLoop(IOptionsSnapshot<LaunchOptions> launchOptions)
    {
        _launchOptions = launchOptions.Value;
    }

    private void InitializeGame()
    {
        System.Console.WriteLine("INIT");
        System.Console.WriteLine(_launchOptions);
        System.Console.CursorVisible = false;
        System.Console.Title = "Conways Game of Life";
#pragma warning disable CA1416 // This call is not reachable on all platforms. Windows only
        System.Console.BufferHeight = _launchOptions.FieldHeight;
        System.Console.BufferWidth = _launchOptions.FieldWidth;
#pragma warning restore CA1416
    }

    /// <inheritdoc />
    public Task StartAsync(CancellationToken cancellationToken)
    {
        InitializeGame();
        return _completedTask;
    }

    /// <inheritdoc />
    public Task StopAsync(CancellationToken cancellationToken)
    {
        return _completedTask;
    }
}