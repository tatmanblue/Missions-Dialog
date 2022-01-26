﻿using System.Collections.Generic;
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
        public event MissionCompleted OnMissionCompleted;
        public event MissionEngineInitialized OnEngineInitialized;
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
                    ProcessActiveMission(MissionServiceLocator.Instance.PlayerData.ActiveMissionStepId);
                }
            }
        }

        private void ProcessActiveMission(int stepId = 1)
        {

            if (0 == ActiveMission.Steps.Count) return;

            ActiveStep = ActiveMission.Steps.Find(s =>
                s.Id == stepId);

            if (null == ActiveStep) return;

            FireMissionStepLoaded();
            
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