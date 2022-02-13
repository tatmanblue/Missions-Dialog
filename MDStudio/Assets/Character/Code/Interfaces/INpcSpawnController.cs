using UnityEngine;

namespace TatmanGames.Character.Interfaces
{
    public interface INpcSpawnController
    {
        bool CanSpawnAtStartup(INpcSpawnPoint point);
        GameObject[] GetAllNpcSpawnPoints();
    }
}