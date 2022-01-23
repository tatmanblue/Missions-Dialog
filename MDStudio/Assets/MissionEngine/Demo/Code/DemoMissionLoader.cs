using System;
using System.Collections.Generic;
using TatmanGames.Missions.Interfaces;

namespace TatmanGames.Missions.Demo
{
    public class DemoMissionLoader : IMissionLoader
    {

        public List<IMission> ReadAllMissions()
        {
            List<IMission> results = new List<IMission>();

            results.Add(new Mission1());
            results.Add(new Mission2());
            return results;
        }

        public IMission ReadMission(int id)
        {
            switch (id)
            {
                case 1:
                    return new Mission1();
                case 2:
                    return new Mission2();
                default:
                    break;
            }

            throw new ApplicationException($"mission {id} isn't defined in demo app");
        }
    }
}