using TatmanGames.Character.Interfaces;
using UnityEngine;

namespace TatmanGames.Character.Spawning
{
    public class SpawnEngine : ISpawnEngine
    {
        public string SpawnTag { get; private set; } = "SpawnPoint";
        public event GameObjectInstantiated OnNpcInstantiated;
        public event GameObjectAutoSpawningCompleted OnAutoSpawningComplete;

        public GameObject Instantiate(GameObject something, ISpawnPoint point)
        {
            GameObject npc = GameObject.Instantiate(point.Data.SpawnableObject, something.transform.position, something.transform.rotation);
            FireOnNpcInstantiated(point, npc);
            return npc;
        }

        private void FireOnNpcInstantiated(ISpawnPoint point, GameObject npc)
        {
            GameObjectInstantiated instantiated = OnNpcInstantiated;
            if (null == instantiated)
                return;

            instantiated(point, npc);
        }

        private void FireAutoSpawningComplete()
        {
            GameObjectAutoSpawningCompleted completed = OnAutoSpawningComplete;
            if (null == completed)
                return;

            completed();
        }
    }
}