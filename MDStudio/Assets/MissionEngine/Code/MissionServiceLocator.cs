using TatmanGames.Missions.Interfaces;

namespace TatmanGames.Missions
{
    public class MissionServiceLocator
    {
        public static MissionServiceLocator Instance { get; private set; } = new MissionServiceLocator();
        public IMissionEngine Engine { get; set; } = new MissionEngine();
        public IMissionLoader Loader { get; set; }
        public IMissionPlayerData PlayerData { get; set; }
        
    }
}