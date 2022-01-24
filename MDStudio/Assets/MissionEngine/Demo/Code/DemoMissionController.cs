using System;
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
            engine.Initialize();
        }

        private void OnMissionLoaded(IMission m)
        {
            missionState.text = $"{m.Name} is active mission.";
        }

        private void OnMissionEngineInitialized()
        {
            engineState.text = "Engine is started";
        }
    }
}