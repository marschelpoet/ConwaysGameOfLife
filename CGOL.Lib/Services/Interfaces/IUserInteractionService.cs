namespace CGOL.Lib.Services.Interfaces;

public interface IUserInteractionService<TInteractionTrigger>
{
    void RegisterInteraction(TInteractionTrigger trigger, NamedAction action);

    IEnumerable<KeyValuePair<TInteractionTrigger, string>> GetAvailableInteractions();

    IEnumerable<string> GetAvailableInteractionsAsStrings();

    bool IsInteractionAvailable(out TInteractionTrigger availableTrigger);

    void RespondToInteraction(TInteractionTrigger trigger);
}