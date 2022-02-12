using TatmanGames.Character.Interfaces;
using UnityEngine;

namespace TatmanGames.Character.NPC
{
    public class NPCEngine : INpcEngine
    {
        public string SpawnTag { get; private set; } = "NPCSpawn";
        public event NpcInstantiated OnNpcInstantiated;
        public event NpcAutoSpawningCompleted OnAutoSpawningComplete;

        public GameObject Instantiate(GameObject something, INpcSpawnPoint point)
        {
            GameObject npc = GameObject.Instantiate(point.Data.NpcAvatar, something.transform.position, something.transform.rotation);
            FireOnNpcInstantiated(point, npc);
            return npc;
        }

        private void FireOnNpcInstantiated(INpcSpawnPoint point, GameObject npc)
        {
            NpcInstantiated instantiated = OnNpcInstantiated;
            if (null == instantiated)
                return;

            instantiated(point, npc);
        }

        private void FireAutoSpawningComplete()
        {
            NpcAutoSpawningCompleted completed = OnAutoSpawningComplete;
            if (null == completed)
                return;

            completed();
        }
    }
}