using Microsoft.Extensions.Options;

namespace CGOL.Console.Services;

public class GameLoop : IHostedService
{
    private readonly Task _completedTask = Task.CompletedTask;
    private readonly IOptionsSnapshot<LaunchOptions> _launchOptions;

    public GameLoop(IOptionsSnapshot<LaunchOptions> launchOptions)
    {
        _launchOptions = launchOptions;
    }

    private void InitializeGame()
    {
        System.Console.WriteLine("INIT");
        System.Console.WriteLine(_launchOptions);
    }

    /// <inheritdoc />
    public Task StartAsync(CancellationToken cancellationToken)
    {
        System.Console.WriteLine("START");
        InitializeGame();
        return _completedTask;
    }

    /// <inheritdoc />
    public Task StopAsync(CancellationToken cancellationToken)
    {
        System.Console.WriteLine("STOP");
        return _completedTask;
    }
}