using System;
using System.Collections.Generic;
using TatmanGames.Common;
using TatmanGames.Common.ServiceLocator;
using TatmanGames.Missions.Interfaces;
using TatmanGames.Missions.Scriptables;
using TatmanGames.ScreenUI.Interfaces;
using TatmanGames.ScreenUI.UI;
using TMPro;
using UnityEngine;

namespace TatmanGames.Missions.Demo
{
    public class UmaDemoMissionController : MonoBehaviour, IMissionLoader
    {
        [SerializeField] private List<MissionData> missions = new List<MissionData>();
        [SerializeField] private TMP_Text missionState;
        [SerializeField] private GameObject missionDialog;
        [SerializeField] private Canvas canvas;
        
        private IMissionEngine engine = null;
        private IPopupHandler popupHandler = null;
        private void Awake()
        {
            var dialogEvents = new PopupEventsManager();
            
            ServicesLocator services = GlobalServicesLocator.Instance;
            popupHandler = new PopupHandler(dialogEvents);
            popupHandler.Canvas = canvas;
            
            services.AddService<IPopupHandler>(popupHandler);
            services.AddService<IPopupEventsManager>(dialogEvents);
            services.AddService<IDialogEvents>(dialogEvents);
            
            dialogEvents.OnButtonPressed += DialogEventsOnButtonPressed;
            
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

            GlobalServicesLocator.Instance.AddReplaceService<IMissionLoader>(this);
            GlobalServicesLocator.Instance.AddReplaceService<IMissionPlayerData>(new DemoPlayerData());

            engine.OnEngineInitialized += OnMissionEngineInitialized;
            engine.OnMissionEngineStopped += OnMissionEngineStopped;
            engine.OnMissionStarted += OnMissionStarted;
            engine.OnMissionStepStarted += OnMissionStepStarted;
            engine.OnMissionStepCompleted += OnMissionStepCompleted;
            engine.OnMissionCompleted += OnMissionCompleted;
            engine.Initialize();
            
        }

        private void OnDestroy()
        {
            engine.OnEngineInitialized -= OnMissionEngineInitialized;
            engine.OnMissionEngineStopped -= OnMissionEngineStopped;
            engine.OnMissionStarted -= OnMissionStarted;
            engine.OnMissionStepStarted -= OnMissionStepStarted;
            engine.OnMissionStepCompleted -= OnMissionStepCompleted;
            engine.OnMissionCompleted -= OnMissionCompleted;
        }

        #region dialog events
        private bool DialogEventsOnButtonPressed(string dialogName, string buttonId)
        {
            if (true == dialogName.Contains("MissionDialog") && true == buttonId.Contains("proceed"))
            {
                SetMissionMessage($"mission screen proceed detected. {dialogName} {buttonId}");
                GlobalServicesLocator.Instance.GetService<IPopupHandler>()?.CloseDialog();
            }

            return false;
        }
        #endregion
        
        #region Mission Events
        private void OnMissionCompleted(IMission m)
        {
            SetMissionMessage($"mission {m.Name}({m.Id}) completed.");
        }

        private void OnMissionStepCompleted(IMissionStep s)
        {
            SetMissionMessage($"mission {s.Name}({s.Id}/{s.MissionId}) completed.");
        }

        private void OnMissionStepStarted(IMissionStep s)
        {
            SetMissionMessage($"mission {s.Name}({s.MissionId}.{s.Id}) started.");
            ShowMissionDialog(null, s);
        }

        private void OnMissionStarted(IMission m)
        {
            SetMissionMessage($"mission {m.Name}({m.Id}) started.");
            if (0 == m.Steps.Count)
                ShowMissionDialog(m, null);
        }

        private void OnMissionEngineStopped()
        {
            SetMissionMessage("mission engine stopped");
        }

        private void OnMissionEngineInitialized()
        {
            SetMissionMessage("mission engine initialized");
            IMissionPlayerData playerData =
                GlobalServicesLocator.Instance.GetService<IMissionPlayerData>();
            
            playerData.Initialize();
        }
        #endregion

        #region Private methods
        private void SetMissionMessage(string msg)
        {
            if (null == missionState)
                return;

            missionState.text = msg;
        }

        public void ShowMissionDialog(IMission m, IMissionStep s)
        {
            if (null == s)
                SetMissionMessage("showing mission dialog");
            else
                SetMissionMessage("Showing mission dialog with step");
            
            popupHandler.ShowDialog(missionDialog);
        }
        #endregion

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