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
        public event MissionCompleted OnMissionCompleted;
        public event MissionEngineStopped OnMissionEngineStopped;
        
        public void Initialize()
        {
            IMissionLoader loader = MissionServiceLocator.Instance.Loader;
            AllMissions = loader?.ReadAllMissions();
            AllMissions?.Sort();
            FireEngineInitialized();

            if (null != MissionServiceLocator.Instance.PlayerData)
            {
                IMission activeMission = loader?.ReadMission(MissionServiceLocator.Instance.PlayerData.ActiveMissionId);
                if (null == activeMission)
                    return;

                ActiveMission = AllMissions.Find(m => m.Id == activeMission.Id);
                if (null != ActiveMission)
                {
                    FireMissionLoaded();
                }
            }
                
        }
        
        public void CompleteActiveMission()
        {
            if (null == ActiveMission)
                throw new MissionEngineError("there is no active mission");
            
            if (false == ActiveMission?.IsCompleted())
                throw new MissionEngineError($"mission id {ActiveMission.Id} is not complete.");
            
            // this is pretty powerful function, theres no checks in place
            FireMissionCompleted();
            
            // get next mission and make it the active one
            int activeMissionIndex = AllMissions.IndexOf(ActiveMission) + 1;
            if (activeMissionIndex >= AllMissions.Count)
            {
                ActiveMission = null;
                FireMissionEngineStopped();
                return;
            }

            ActiveMission = AllMissions[activeMissionIndex];
            FireMissionLoaded();
        }

        private void FireEngineInitialized()
        {
            MissionEngineInitialized initialized = OnEngineInitialized;

            if (null == initialized) return;

            initialized();
        }

        private void FireMissionLoaded()
        {
            MissionStarted started = OnMissionLoaded;
            if (null == started) return;

            started(ActiveMission);
        }

        private void FireMissionCompleted()
        {
            MissionCompleted completed = OnMissionCompleted;
            if (null == completed) return;

            completed(ActiveMission);
        }

        private void FireMissionEngineStopped()
        {
            MissionEngineStopped stopped = OnMissionEngineStopped;
            if (null == stopped) return;
            stopped();
        }
    }
}