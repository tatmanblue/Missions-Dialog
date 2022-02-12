
using UnityEngine;

namespace TatmanGames.Character.Interfaces
{
    public interface INpcEngine
    {
        string SpawnTag { get; }
        event NpcInstantiated OnNpcInstantiated;
        event NpcAutoSpawningCompleted OnAutoSpawningComplete;
        
        GameObject Instantiate(GameObject something, INpcSpawnPoint point);
    }
}