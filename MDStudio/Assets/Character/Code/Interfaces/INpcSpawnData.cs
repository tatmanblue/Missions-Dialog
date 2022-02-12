using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TatmanGames.Character.Interfaces
{
    public interface INpcSpawnData
    {
        /// <summary>
        /// an Id for the NPC instance
        /// </summary>
        int Id { get; }
        GameObject NpcAvatar { get; }
    }
}
