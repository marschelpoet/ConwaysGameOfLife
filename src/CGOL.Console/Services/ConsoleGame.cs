using CGOL.Lib.Services.Interfaces;

namespace CGOL.Console.Services;

public class ConsoleGame : IHostedService
{
    private readonly IGameLoop _gameLoop;
    private readonly Task _completedTask = Task.CompletedTask;

    public ConsoleGame(
        IOptions<LaunchOptions> options,
        IGameLoop gameLoop)
    {
        _gameLoop = gameLoop;
    }

    /// <inheritdoc />
    public Task StartAsync(CancellationToken cancellationToken)
    {
        return Task.Run(_gameLoop.RunGame, cancellationToken);

    }

    /// <inheritdoc />
    public Task StopAsync(CancellationToken cancellationToken)
    {
        _gameLoop.Stop();
        return _completedTask;
    }
}