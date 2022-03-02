namespace TatmanGames.Missions.Interfaces
{
    /// <summary>
    /// Intended to be an inmemory store of mission states.
    ///
    /// Allows IMission and IMissionSteps share their state without requiring those
    /// implementations to actually maintain state since state belongs to the player
    ///
    /// Allows separation of IMissionEngine from state information and from player
    ///
    /// It is not meant to serialize state data such as game save
    /// </summary>
    public interface IMissionStateAggregator
    {
        void SetCompleteState(IMission mission, IMissionStep step, bool state);
        bool IsComplete(IMission mission, IMissionStep step);
    }
}