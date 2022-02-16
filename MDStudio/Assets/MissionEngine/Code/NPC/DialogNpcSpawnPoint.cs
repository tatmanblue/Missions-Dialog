using TatmanGames.Character.Interfaces;
using TatmanGames.Missions.Scriptables;
using UnityEngine;

namespace TatmanGames.Missions.NPC
{
    public class DialogNpcSpawnPoint : MonoBehaviour, INpcSpawnPoint
    {
        public INpcSpawnData Data 
        {
            get
            {
                return spawnData;
            }
        }
        
        [SerializeField] private DialogNpcSpawnData spawnData;
    }
}