﻿using System;
using TatmanGames.Common;
using TatmanGames.Common.ServiceLocator;
using TatmanGames.Missions.Interfaces;
using TMPro;
using UnityEngine;

namespace TatmanGames.Missions.Demo
{
    /*
     * Example of how to initialize and interact with the mission engine
     */
    public class DemoMissionController : MonoBehaviour
    {
        #region things added just to keep demo simple
        [SerializeField] private TMP_Text engineState;
        [SerializeField] private TMP_Text missionState;
        [SerializeField] private TMP_Text missionName;
        [SerializeField] private TMP_Text missionDesc;
        [SerializeField] private TMP_Text stepName;
        [SerializeField] private TMP_Text stepDesc;
        #endregion

        private IMissionEngine engine = null;
        
        private void Awake()
        {
            try
            {
                engine = GlobalServicesLocator.Instance.GetService<IMissionEngine>();
            }
            catch (ServiceLocatorException)
            {
                if (null == engine)
                {
                    engine = new MissionEngine();
                    GlobalServicesLocator.Instance.AddService<IMissionEngine>(engine);
                }
            }

            GlobalServicesLocator.Instance.AddReplaceService<IMissionLoader>(new DemoMissionLoader());
            GlobalServicesLocator.Instance.AddReplaceService<IMissionPlayerData>(new DemoPlayerData());

            engine.OnEngineInitialized += OnMissionEngineInitialized;
            engine.OnMissionEngineStopped += OnMissionEngineStopped;
            engine.OnMissionStarted += OnMissionStarted;
            engine.OnMissionStepStarted += OnMissionStepStarted;
            engine.OnMissionStepCompleted += OnMissionStepCompleted;
            engine.OnMissionCompleted += OnMissionCompleted;
            engine.Initialize();
        }

        private void OnMissionCompleted(IMission m)
        {
            missionState.text = $"{m.Name} is completed.";
        }

        private void OnMissionEngineStopped()
        {
            engineState.text = "Engine is stopped.  All missions Completed";
            missionState.text = $"there are no active missions";
            missionName.text = "";
            missionDesc.text = "";
            stepName.text = "";
            stepDesc.text = "";
        }

        private void OnMissionStarted(IMission m)
        {
            missionState.text = $"{m.Name} is active mission.";
            missionName.text = m.Name;
            missionDesc.text = m.Description;
        }

        private void OnMissionStepStarted(IMissionStep s)
        {
            stepName.text = s.Name;
            stepDesc.text = s.Description;
        }

        private void OnMissionStepCompleted(IMissionStep s)
        {
            stepName.text = "";
            stepDesc.text = "";
        }
        
        private void OnMissionEngineInitialized()
        {
            engineState.text = "Engine is started";
            IMissionPlayerData playerData =
                GlobalServicesLocator.Instance.GetService<IMissionPlayerData>();
            
            playerData.Initialize();
            
        }

        /**
         * used by buttons in screen to invoke mission complete
         */
        public void FireMissionCompleteEvent()
        {
            engine?.CompleteActiveMission();
        }

        public void FireStepCompleteEvent()
        {
            engine?.CompleteActiveMissionStep();
        }
    }
}