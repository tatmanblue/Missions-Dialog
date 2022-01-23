using System.Collections.Generic;

namespace TatmanGames.Missions.Interfaces
{
	public interface IMissionEngine
	{
		IMission ActiveMission { get; }
		List<IMission> AllMissions { get; }

		event MissionStarted OnMissionLoaded;
		event MissionEngineInitialized OnEngineInitialized;
		void Initialize();
	}
}