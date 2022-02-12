using TatmanGames.Character.Interfaces;

namespace TatmanGames.Character
{
    public class NPCServiceLocator
    {
        public INpcEngine Engine { get; set; }
        public static NPCServiceLocator Instance { get; private set; } = new NPCServiceLocator();
    }
}