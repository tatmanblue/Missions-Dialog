using TatmanGames.Missions.Interfaces;

namespace TatmanGames.Missions
{
    public delegate void MissionEngineInitialized();
    public delegate void MissionStarted(IMission m);

    public delegate void MissionCompleted(IMission m);

    public delegate void MissionAbandon(IMission m);

    public delegate void MissionStepStarted(IMissionStep s);

    public delegate void MissionStepCompleted(IMissionStep s);

    public delegate void MissionEngineStopped();
}