using TatmanGames.Common.ServiceLocator;
using TatmanGames.Missions.Interfaces;

namespace TatmanGames.Missions
{
    public static class MissionExtensions
    {
        public static bool CheckIsComplete(this IMission mission)
        {
            return false;
        }

        public static bool CheckIsComplete(this IMissionStep step)
        {
            IMissionStateAggregator aggregator = GlobalServicesLocator.Instance.GetService<IMissionStateAggregator>();
            IMissionEngine engine = GlobalServicesLocator.Instance.GetService<IMissionEngine>();
            IMission activeMission = engine.ActiveMission;
            IMissionStep activeStep = engine.ActiveStep;
            
            // is there any reason we should check that ActiveMission = this.Mission
            // and ActiveStep.Id = this.Id
            
            return aggregator.IsComplete(activeMission, activeStep);
        }
    }
}