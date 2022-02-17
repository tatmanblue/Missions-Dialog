using TatmanGames.Character;
using TatmanGames.Character.Interfaces;
using TatmanGames.Missions.Interfaces;
using UnityEngine;

namespace TatmanGames.Missions.NPC
{
    public class DialogNpcSpawnController : INpcSpawnController
    {
        public bool CanSpawnAtStartup(INpcSpawnPoint point)
        {
            IDialogNpcSpawnData data = point.Data as IDialogNpcSpawnData;
            if (null == data)
                return true;

            return data.AutomaticSpawning;
        }

        public GameObject[] GetAllNpcSpawnPoints()
        {
            return GameObject.FindGameObjectsWithTag(NpcServiceLocator.Instance.Engine?.SpawnTag);
        }
    }
}