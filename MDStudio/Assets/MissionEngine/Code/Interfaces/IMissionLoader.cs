using System.Collections.Generic;

namespace TatmanGames.Missions.Interfaces
{
    public interface IMissionLoader
    {
        IMission ActiveMission { get; }
        List<IMission> AllMissions { get; }
    }
}