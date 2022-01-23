using System.Collections.Generic;
using TatmanGames.Missions.Interfaces;

namespace TatmanGames.Missions.Demo.Code
{
    public class DemoMissionLoader : IMissionLoader
    {
        public IMission ActiveMission
        {
            get { return GetActiveMission(); }
        }
        public List<IMission> AllMissions
        {
            get { return GetAllMissions();  }
        }

        private IMission GetActiveMission()
        {
            return new Mission1();
        }

        private List<IMission> GetAllMissions()
        {
            List<IMission> results = new List<IMission>();

            results.Add(new Mission1());
            results.Add(new Mission2());
            return results;
        }
    }
}