namespace TatmanGames.Missions.Interfaces
{
    /// <summary>
    /// Data required for npc spawn engine to wire up conversations (dialog)
    /// </summary>
    public interface IDialogNpcSpawnData
    {
        int MissionId { get; }
        int MissionStepId { get; }
    }
}