namespace CGOL.Console.Services;

public class GameLoop : IHostedService
{
    private bool _run = true;
    private readonly IOptionsValidator _optionsValidator;
    private readonly IUserInteractionService<ConsoleKey> _userInteractionService;
    private readonly Task _completedTask = Task.CompletedTask;
    private readonly LaunchOptions _launchOptions;

    public GameLoop(
        IOptionsSnapshot<LaunchOptions> launchOptions,
        IOptionsValidator optionsValidator,
        IUserInteractionService<ConsoleKey> userInteractionService)
    {
        _optionsValidator = optionsValidator;
        _userInteractionService = userInteractionService;
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

        _userInteractionService.RegisterInteraction(ConsoleKey.X, new()
        {
            Action = () => { _run = false; },
            Name = "Exit"
        });
    }

    private void InitializeGame()
    {
        // TODO:
        // initialize the game object 
        // Seeding
        // Load saves files
    }

    /// <inheritdoc />
    public Task StartAsync(CancellationToken cancellationToken)
    {
        InitializeConsole();
        InitializeGame();
        RunGame();
        return _completedTask;
    }

    private void RunGame()
    {
        // TODO:
        // Run infinite loop x
        //  each loop is 1 game round x
        // 1. Check for available User input and react accordingly x
        // 2. Advance the game of life 
        // 3. Clear console and print new state 
        // 3.1. Print menu line 
        // 3.2. Print Game of life 
        // 4. Loop end when game dead or user quits 

        do
        {
            // Print

            // User interaction
            if (_userInteractionService.IsInteractionAvailable(out ConsoleKey userInteraction))
            {
                _userInteractionService.RespondToInteraction(userInteraction);
            }

            System.Console.WriteLine("Press X to quit");
            Thread.Sleep(500);

            // Advance Game

        } while (_run);
    }

    /// <inheritdoc />
    public Task StopAsync(CancellationToken cancellationToken)
    {
        return _completedTask;
    }
}