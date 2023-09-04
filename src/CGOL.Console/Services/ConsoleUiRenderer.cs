using CGOL.Console.Constants;
using CGOL.Lib.Configuration;
using CGOL.Lib.Services;
using CGOL.Lib.Services.Interfaces;

namespace CGOL.Console.Services;

public class ConsoleUiRenderer : IUiRenderer
{
    private readonly GameOfLifeOptions _options;
    private readonly IUserInteractionService<ConsoleKey> _userInteractionService;
    private readonly IReadonlyConwaysGameOfLife _gameOfLife;

    public ConsoleUiRenderer(
        IOptions<GameOfLifeOptions> options,
        IUserInteractionService<ConsoleKey> userInteractionService,
        IConwaysGameOfLife gameOfLife)
    {
        _options = options.Value;
        _userInteractionService = userInteractionService;
        _gameOfLife = gameOfLife;
    }

    /// <inheritdoc />
    public void InitializeUi()
    {
        System.Console.CursorVisible = false;
        System.Console.Title = "Conways Game of Life";

        if (OperatingSystem.IsWindows())
        {
            System.Console.SetWindowSize(_options.Width, _options.Height + ConsoleConstants.NumberOfReservedBufferRows);
            System.Console.BufferHeight = _options.Height + ConsoleConstants.NumberOfReservedBufferRows;
            System.Console.BufferWidth = _options.Width;
        }
    }

    /// <inheritdoc />
    public void InitializeUserInteractions()
    {
        _userInteractionService.RegisterInteraction(ConsoleKey.X, AbstractGameLoop.ExitAction);
        _userInteractionService.RegisterInteraction(ConsoleKey.P, AbstractGameLoop.PauseAction);
    }

    /// <inheritdoc />
    public void InitializeNewFrame()
    {
        System.Console.Clear();
    }

    /// <inheritdoc />
    public void RenderMenuStructure(params string[] menuItems)
    {
        foreach (string menuItem in menuItems)
        {
            System.Console.Write("| {0} ", menuItem);
        }

        System.Console.WriteLine(" |");
    }

    /// <inheritdoc />
    public void RenderGame()
    {
        System.Console.Write(_gameOfLife.ToString());
    }
}