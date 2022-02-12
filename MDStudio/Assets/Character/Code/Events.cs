using TatmanGames.Character.Interfaces;
using UnityEngine;

namespace TatmanGames.Character
{
    /// <summary>
    /// an npc spawn has been created 
    /// </summary>
    public delegate void NpcInstantiated(INpcSpawnPoint point, GameObject npc);
    public delegate void NpcAutoSpawningCompleted();
}