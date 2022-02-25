using System.Collections.Generic;
using TatmanGames.Common;
using TatmanGames.Common.ServiceLocator;
using TatmanGames.Missions.Interfaces;
using TatmanGames.Missions.Scriptables;
using UnityEngine;

namespace TatmanGames.Missions.Demo
{
    public class UmaDemoMissionController : MonoBehaviour, IMissionLoader
    {
        [SerializeField] private List<MissionData> missions = new List<MissionData>();
        private IMissionEngine engine = null;
        private void Awake()
        {
            try
            {
                engine = GlobalServicesLocator.Instance.GetServiceByName<IMissionEngine>(MissionServiceLocator.Engine);
            }
            catch (ServiceLocatorException)
            {
                if (null == engine)
                {
                    engine = new MissionEngine();
                    GlobalServicesLocator.Instance.AddService(MissionServiceLocator.Engine, engine);
                }
            }

            GlobalServicesLocator.Instance.AddService(MissionServiceLocator.Loader, this);
            GlobalServicesLocator.Instance.AddService(MissionServiceLocator.PlayerData, new DemoPlayerData());

            /*
            engine.OnEngineInitialized += OnMissionEngineInitialized;
            engine.OnMissionEngineStopped += OnMissionEngineStopped;
            engine.OnMissionStarted += OnMissionStarted;
            engine.OnMissionStepStarted += OnMissionStepStarted;
            engine.OnMissionStepCompleted += OnMissionStepCompleted;
            engine.OnMissionCompleted += OnMissionCompleted;
            */
            engine.Initialize();
        }

        public List<IMission> ReadAllMissions()
        {
            List<IMission> list = new List<IMission>();

            foreach (var step in missions)
            {
                list.Add(step);
            }
            return list;
        }

        public IMission ReadMission(int id)
        {
            return missions.Find(m => m.Id == id);
        }
    }
}