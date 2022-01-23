using TatmanGames.Missions.Interfaces;

namespace TatmanGames.Missions.Demo
{
    public class Mission1 : IMission
    {
        public int Id { get; private set; } = 1;
        public int ParentId { get; private set; } = -1;
        public string Uuid { get; private set; } = string.Empty;
        public string Name { get; private set; } = "Mission One";
        public string Description { get; private set; } = "This is the first mission";
    }
    
    public class Mission2 : IMission
    {
        public int Id { get; private set; } = 2;
        public int ParentId { get; private set; } = 1;
        public string Uuid { get; private set; } = string.Empty;
        public string Name { get; private set; } = "Mission Two";
        public string Description { get; private set; } = "This is the next mission, after the first one";
    }
}