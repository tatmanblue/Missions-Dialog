using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TatmanGames.Character.Interfaces
{
    /// <summary>
    /// This is the data the engine and controller will use to initialize and place
    /// an Npc in the scene.
    /// </summary>
    public interface INpcSpawnData
    {
        /// <summary>
        /// an Id for the NPC instance
        /// keep it unique so that consumers can identity the npc instance easily
        /// </summary>
        int Id { get; }
        bool DestroyPointOnSpawn { get; }
        GameObject NpcAvatar { get; }
    }
}
