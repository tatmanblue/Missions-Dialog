using System.Collections;
using System.Collections.Generic;
using TatmanGames.Character.Interfaces;
using TatmanGames.Missions.Interfaces;
using UnityEngine;

namespace TatmanGames.Missions.Scriptables
{
    [CreateAssetMenu(fileName = "DialogSpawnData", menuName = "Tatman Games/Missions/Dialog NPC Spawn Data")]
    public class DialogNpcSpawnData : ScriptableObject, INpcSpawnData, IDialogNpcSpawnData
    {
        public int Id
        {
            get { return id; }
        }

        public bool DestroyPointOnSpawn
        {
            get { return true; }
        }

        public GameObject NpcAvatar {
            get
            {
                return npcAvatar;
            }
        }

        public bool AutomaticSpawning
        {
            get
            {
                return automaticSpawning;
            }
        }
        
        [SerializeField] private int id;
        [SerializeField] private GameObject npcAvatar;
        [SerializeField] private bool automaticSpawning;
    }
}
