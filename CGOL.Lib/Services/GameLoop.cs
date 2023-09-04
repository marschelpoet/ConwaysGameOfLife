using CGOL.Lib.Configuration;

using Microsoft.Extensions.Options;

namespace CGOL.Lib.Services;

public class GameLoop<TInteractionTrigger> : AbstractGameLoop
{
    private readonly IUserInteractionService<TInteractionTrigger> _userInteractionService;
    private readonly IUiRenderer _uiRenderer;
    private readonly IConwaysGameOfLife _game;
    private readonly int _gameSpeed;

    public GameLoop(
        IUserInteractionService<TInteractionTrigger> userInteractionService,
        IUiRenderer uiRenderer,
        IConwaysGameOfLife game,
        IOptionsSnapshot<GameOfLifeOptions> options)
    {
        _userInteractionService = userInteractionService;
        _uiRenderer = uiRenderer;
        _game = game;
        _gameSpeed = options.Value.Speed;
        _uiRenderer.Initialize();
        _game.Initialize();
    }

    public override void RunGame()
    {
        do
        {
            // User interaction
            if (_userInteractionService.IsInteractionAvailable(out TInteractionTrigger userInteraction))
            {
                _userInteractionService.RespondToInteraction(userInteraction!);
            }

            // Delay for visual effect
            Thread.Sleep(_gameSpeed);

            // Print
            _uiRenderer.RenderUi(GetMenuItems().ToArray());

            if (!PauseGame)
            {
                // Advance Game
                _game.Advance();
            }
        } while (Run);
    }

    private IEnumerable<string> GetMenuItems()
    {
        List<string> result = new()
        {
            $"Generation: {_game.GetCurrentGeneration(),4}",
            $"Game {(PauseGame ? "paused" : "running")}"
        };

        result.AddRange(_userInteractionService.GetAvailableInteractionsAsStrings());
        return result;
    }
}