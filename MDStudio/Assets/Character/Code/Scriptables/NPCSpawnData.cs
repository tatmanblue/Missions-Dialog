using System.Collections;
using System.Collections.Generic;
using TatmanGames.Character.Interfaces;
using UnityEngine;

namespace TatmanGames.Character.Scriptables
{

    /// <summary>
    /// a persisted view, so to speak, into a model INPCSpawnData
    /// </summary>
    [CreateAssetMenu(fileName = "SpawnData", menuName = "Tatman Games/Characters/NPC Spawner")]
    public class NPCSpawnData : ScriptableObject, INpcSpawnData
    {
        public int Id
        {
            get { return id; }
        }

        public GameObject NpcAvatar {
            get
            {
                return npcAvatar;
            }
        }


        [SerializeField] private int id;
        [SerializeField] private GameObject npcAvatar;
    }

}
