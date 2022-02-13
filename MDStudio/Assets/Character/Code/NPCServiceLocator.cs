using TatmanGames.Character.Interfaces;
using UnityEngine;

namespace TatmanGames.Character
{
    public class NpcServiceLocator
    {
        public INpcEngine Engine { get; set; }
        public INpcSpawnController Controller { get; set; }
        public static NpcServiceLocator Instance { get; private set; } = new NpcServiceLocator();
    }
}