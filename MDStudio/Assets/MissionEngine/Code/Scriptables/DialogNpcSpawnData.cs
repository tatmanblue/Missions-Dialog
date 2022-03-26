using System.Collections;
using System.Collections.Generic;
using TatmanGames.Character.Interfaces;
using TatmanGames.Missions.Interfaces;
using UnityEngine;

namespace TatmanGames.Missions.Scriptables
{
    [CreateAssetMenu(fileName = "DialogSpawnData", menuName = "Tatman Games/Dialog NPC Spawn Data")]
    public class DialogNpcSpawnData : ScriptableObject, ISpawnData
    {
        public int Id
        {
            get { return id; }
        }

        public bool SpawnOnStart
        {
            get { return automaticSpawning; }
        }

        public bool DestroyPointOnSpawn
        {
            get { return true; }
        }

        public GameObject SpawnableObject 
        {
            get
            {
                return npcAvatar;
            }
        }
        
        [SerializeField] private int id;
        [SerializeField] private GameObject npcAvatar;
        [SerializeField] private bool automaticSpawning;
    }
}
