using TatmanGames.Missions.Interfaces;

namespace TatmanGames.Missions.Demo
{
    public class DemoPlayerData : IMissionPlayerData
    {
        public int ActiveMissionId { get; set; } = 1;

        public int ActiveMissionStepId { get; set; } = 0;
    }
}