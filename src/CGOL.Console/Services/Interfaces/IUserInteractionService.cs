using CGOL.Console.Models;

namespace CGOL.Console.Services.Interfaces;

public interface IUserInteractionService<TInteractionTrigger>
{
    void RegisterInteraction(TInteractionTrigger trigger, NamedAction action);

    IEnumerable<KeyValuePair<TInteractionTrigger, string>> GetAvailableInteractions();

    bool IsInteractionAvailable(out TInteractionTrigger? availableTrigger);

    void RespondToInteraction(TInteractionTrigger trigger);
}