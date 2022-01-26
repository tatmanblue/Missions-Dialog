using System;

namespace TatmanGames.Missions.Interfaces
{
    /// <summary>
    /// inherit the IMission so that we have a distinct type
    /// (not sure if this is the best approach)
    /// </summary>
    public interface IMissionStep : IComparable
    {
        int Id { get; }
        int ParentId { get; }
        int MissionId { get; }
        string Uuid { get; }
        string Name { get; }
        string Description { get; }

        bool IsCompleted();
    }
}