﻿using System;
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
        #endregion
        
        private void Awake()
        {
            if (null == MissionServiceLocator.Instance.Engine)
                return;

            MissionServiceLocator.Instance.Loader = new DemoMissionLoader();
            MissionServiceLocator.Instance.PlayerData = new DemoPlayerData();
            IMissionEngine engine = MissionServiceLocator.Instance.Engine;
            
            engine.OnMissionLoaded += OnMissionLoaded;
            engine.OnEngineInitialized += OnMissionEngineInitialized;
            engine.OnMissionEngineStopped += OnMissionEngineStopped;
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

        }

        private void OnMissionLoaded(IMission m)
        {
            missionState.text = $"{m.Name} is active mission.";
            missionName.text = m.Name;
            missionDesc.text = m.Description;
        }

        private void OnMissionEngineInitialized()
        {
            engineState.text = "Engine is started";
        }

        /**
         * used by buttons in screen to invoke mission complete
         */
        public void FireMissionCompleteEvent()
        {
            MissionServiceLocator.Instance.Engine?.CompleteActiveMission();
        }
    }
}