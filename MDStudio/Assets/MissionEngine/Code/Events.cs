using TatmanGames.Missions.Interfaces;

namespace TatmanGames.Missions.MissionEngine.Code
{
    public delegate void MissionStarted(IMission m);

    public delegate void MissionCompleted(IMission m);

    public delegate void MissionAbandon(IMission m);

    public delegate void MissionStepStarted(IMissionStep s);
}