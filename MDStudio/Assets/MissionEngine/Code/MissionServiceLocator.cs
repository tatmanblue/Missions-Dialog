using TatmanGames.Missions.Interfaces;

namespace TatmanGames.Missions
{
    /// <summary>
    /// constants used to find mission services in the GlobalServiceLocator
    /// </summary>
    public static class MissionServiceLocator
    {
        public static readonly string Engine = "MissionEngine";
        public static readonly string Loader = "MissionLoader";
        public static readonly string PlayerData = "PlayerData";
    }
}