using Microsoft.Extensions.Options;

namespace CGOL.Console.Services;

public class GameLoop : IHostedService
{
    private readonly IOptionsValidator _optionsValidator;
    private readonly Task _completedTask = Task.CompletedTask;
    private readonly LaunchOptions _launchOptions;

    public GameLoop(IOptionsSnapshot<LaunchOptions> launchOptions, IOptionsValidator optionsValidator)
    {
        _optionsValidator = optionsValidator;
        _launchOptions = launchOptions.Value;
    }

    private void InitializeConsole()
    {
        _optionsValidator.ValidateOptionsThrow(_launchOptions);

        System.Console.CursorVisible = false;
        System.Console.Title = "Conways Game of Life";
        // TODO: Check for system agnostic solution
#pragma warning disable CA1416 // This call is not reachable on all platforms. Windows only
        System.Console.SetWindowSize(_launchOptions.Width, _launchOptions.Height);
        System.Console.BufferHeight = _launchOptions.Height;
        System.Console.BufferWidth = _launchOptions.Width;
#pragma warning restore CA1416
    }

    /// <inheritdoc />
    public Task StartAsync(CancellationToken cancellationToken)
    {
        InitializeConsole();
        return _completedTask;
    }

    /// <inheritdoc />
    public Task StopAsync(CancellationToken cancellationToken)
    {
        return _completedTask;
    }
}