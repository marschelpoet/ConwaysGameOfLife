using CGOL.Console.Models;

namespace CGOL.Console.Services;

public class ConsoleUserInteractionService : IUserInteractionService<ConsoleKey>
{
    private readonly Dictionary<ConsoleKey, NamedAction> _availableInteractions;

    public ConsoleUserInteractionService()
    {
        _availableInteractions = new Dictionary<ConsoleKey, NamedAction>
        {
            { ConsoleKey.F24, new NamedAction { Action = () => {}, Name = "Default Empty Action"} }
        };
    }

    /// <inheritdoc />
    public void RegisterInteraction(ConsoleKey trigger, NamedAction action)
    {
        _availableInteractions.Add(trigger, action);
    }

    /// <inheritdoc />
    public IEnumerable<KeyValuePair<ConsoleKey, string>> GetAvailableInteractions()
    {
        return _availableInteractions.Keys.Select(key => new KeyValuePair<ConsoleKey, string>(key, _availableInteractions[key].Name)).ToList();
    }

    /// <inheritdoc />
    public bool IsInteractionAvailable(out ConsoleKey availableTrigger)
    {
        if (System.Console.KeyAvailable)
        {
            availableTrigger = System.Console.ReadKey(true).Key;
            return true;
        }

        availableTrigger = ConsoleKey.F24;
        return false;
    }

    /// <inheritdoc />
    public void RespondToInteraction(ConsoleKey trigger)
    {
        if (_availableInteractions.TryGetValue(trigger, out NamedAction? namedAction))
        {
            namedAction.Action();
        }
    }
}