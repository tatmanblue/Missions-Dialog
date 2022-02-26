using System.Collections.Generic;

namespace TatmanGames.Missions.Interfaces
{
	public interface IMissionEngine
	{
		MissionEngineStates State { get; }
		IMission ActiveMission { get; }
		IMissionStep ActiveStep { get; }
		List<IMission> AllMissions { get; }

		event MissionStarted OnMissionStarted;
		event MissionStepStarted OnMissionStepStarted;
		event MissionStepCompleted OnMissionStepCompleted;
		event MissionCompleted OnMissionCompleted;
		event MissionEngineInitialized OnEngineInitialized;
		event MissionEngineStopped OnMissionEngineStopped;
		void Initialize();
		void StartMissions();
		void CompleteActiveMission();
		void CompleteActiveMissionStep();
	}
}