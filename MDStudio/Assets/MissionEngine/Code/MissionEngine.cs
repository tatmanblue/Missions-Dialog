using System.Collections.Generic;
using TatmanGames.Common.ServiceLocator;
using TatmanGames.Missions.Interfaces;

namespace TatmanGames.Missions
{
    public class MissionEngine : IMissionEngine
    {
        public MissionEngineStates State { get; private set; } = MissionEngineStates.Stopped;
        public IMission ActiveMission { get; private set; } = null;
        public IMissionStep ActiveStep { get; private set; } = null;
        public List<IMission> AllMissions { get; private set; }
        
        public event MissionStarted OnMissionStarted;
        public event MissionStepStarted OnMissionStepStarted;
        public event MissionStepCompleted OnMissionStepCompleted;
        public event MissionCompleted OnMissionCompleted;
        public event MissionEngineInitialized OnEngineInitialized;
        public event MissionEngineStopped OnMissionEngineStopped;
        
        public void Initialize()
        {
            IMissionLoader loader = GlobalServicesLocator.Instance.GetServiceByName<IMissionLoader>(MissionServiceLocator.Loader);
            IMissionPlayerData playerData =
                GlobalServicesLocator.Instance.GetServiceByName<IMissionPlayerData>(MissionServiceLocator.PlayerData); 
            if (null == playerData)
                throw new MissionEngineError("there is no PlayerData to initialize mission engine");
            
            AllMissions = loader?.ReadAllMissions();
            AllMissions?.Sort();
            FireEngineInitialized();
            
            IMission activeMission = loader?.ReadMission(playerData.ActiveMissionId);
            if (null == activeMission)
                return;

            ActiveMission = AllMissions.Find(m => m.Id == activeMission.Id);
            if (null != ActiveMission)
            {
                FireMissionLoaded();
                ProcessActiveMission(playerData.ActiveMissionStepId);
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
                ActiveStep = null;
                FireMissionEngineStopped();
                return;
            }

            ActiveMission = AllMissions[activeMissionIndex];
            FireMissionLoaded();
            ProcessActiveMission();
        }

        public void CompleteActiveMissionStep()
        {
            if (null == ActiveStep)
                throw new MissionEngineError("there is not an active mission step");

            if (false == ActiveStep?.IsCompleted())
                throw new MissionEngineError(
                    $"mission step {ActiveStep.Id} of mission {ActiveMission.Id} is not complete");

            FireMissionStepCompleted();
            int activeStepIndex = ActiveMission.Steps.IndexOf(ActiveStep) + 1;
            if (activeStepIndex >= ActiveMission.Steps.Count)
            {
                ActiveStep = null;
                CompleteActiveMission();
                return;
            }

            ActiveStep = ActiveMission.Steps[activeStepIndex];
            FireMissionStepLoaded();
        }
        
        private void ProcessActiveMission(int stepId = 1)
        {

            if (0 == ActiveMission.Steps.Count) return;

            ActiveStep = ActiveMission.Steps.Find(s =>
                s.Id == stepId);

            if (null == ActiveStep) return;

            FireMissionStepLoaded();
            
        }
        private void FireMissionLoaded()
        {
            MissionStarted started = OnMissionStarted;
            if (null == started) return;

            started(ActiveMission);
        }

        private void FireMissionCompleted()
        {
            MissionCompleted completed = OnMissionCompleted;
            if (null == completed) return;

            completed(ActiveMission);
        }

        private void FireMissionStepLoaded()
        {
            MissionStepStarted stepStarted = OnMissionStepStarted;
            if (null == stepStarted) return;

            stepStarted(ActiveStep);
        }

        private void FireMissionStepCompleted()
        {
            MissionStepCompleted stepCompleted = OnMissionStepCompleted;
            if (null == stepCompleted) return;

            stepCompleted(ActiveStep);
        }
        
        private void FireEngineInitialized()
        {
            MissionEngineInitialized initialized = OnEngineInitialized;

            if (null == initialized) return;

            State = MissionEngineStates.Started;
            initialized();
        }
        
        private void FireMissionEngineStopped()
        {
            MissionEngineStopped stopped = OnMissionEngineStopped;
            if (null == stopped) return;
            State = MissionEngineStates.Stopped;
            stopped();
        }
    }
}