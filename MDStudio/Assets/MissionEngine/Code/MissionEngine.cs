using System.Collections.Generic;
using TatmanGames.Missions.Interfaces;

namespace TatmanGames.Missions
{
    public class MissionEngine : IMissionEngine
    {
        public IMission ActiveMission { get; private set; }
        public List<IMission> AllMissions { get; private set; }
        
        public event MissionStarted OnMissionLoaded;
        public event MissionEngineInitialized OnEngineInitialized;
        
        public void Initialize()
        {
            IMissionLoader loader = MissionServiceLocator.Instance.Loader;
            AllMissions = loader?.ReadAllMissions();
            FireEngineInitialized();

            if (null != MissionServiceLocator.Instance.PlayerData)
            {
                ActiveMission = loader.ReadMission(MissionServiceLocator.Instance.PlayerData.ActiveMissionId);
            }
                
        }

        private void FireEngineInitialized()
        {
            MissionEngineInitialized initialized = OnEngineInitialized;

            if (null == initialized) return;

            initialized();
        }
    }
}