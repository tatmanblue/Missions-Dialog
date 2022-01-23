using System;
using TatmanGames.Missions.Interfaces;
using UnityEngine;

namespace TatmanGames.Missions.Demo
{
    public class DemoMissionController : MonoBehaviour
    {
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

        }

        private void OnMissionEngineInitialized()
        {
            
        }
    }
}