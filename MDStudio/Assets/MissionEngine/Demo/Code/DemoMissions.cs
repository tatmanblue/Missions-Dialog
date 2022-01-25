using TatmanGames.Missions.Interfaces;

namespace TatmanGames.Missions.Demo
{
   
    /**
     * Hardcoded missions for demo purposes
     */
    public class Mission1 : IMission
    {
        public int Id { get; private set; } = 1;
        public int ParentId { get; private set; } = -1;
        public string Uuid { get; private set; } = string.Empty;
        public string Name { get; private set; } = "Mission One";
        public string Description { get; private set; } = "This is the first mission";

        public bool IsCompleted()
        {
            return true;
        }

        public int CompareTo(object obj)
        {
            IMission compareTo = obj as IMission;
            if (Id > compareTo?.Id) return 1;
            if (Id < compareTo?.Id) return -1;
            return 0;
        }
    }
    
    public class Mission2 : IMission
    {
        public int Id { get; private set; } = 2;
        public int ParentId { get; private set; } = 1;
        public string Uuid { get; private set; } = string.Empty;
        public string Name { get; private set; } = "Mission Two";
        public string Description { get; private set; } = "This is the next mission, after the first one";
        public bool IsCompleted()
        {
            return true;
        }
        
        public int CompareTo(object obj)
        {
            IMission compareTo = obj as IMission;
            if (Id > compareTo?.Id) return 1;
            if (Id < compareTo?.Id) return -1;
            return 0;
        }

    }
    
    public class Mission3 : IMission
    {
        public int Id { get; private set; } = 3;
        public int ParentId { get; private set; } = 2;
        public string Uuid { get; private set; } = string.Empty;
        public string Name { get; private set; } = "Mission 3";
        public string Description { get; private set; } = "This is the third mission in the series. And for now its the last but if another one is added this text could be wrong";
        public bool IsCompleted()
        {
            return true;
        }
        
        public int CompareTo(object obj)
        {
            IMission compareTo = obj as IMission;
            if (Id > compareTo?.Id) return 1;
            if (Id < compareTo?.Id) return -1;
            return 0;
        }

    }
}