using System;

namespace TatmanGames.Missions.Interfaces
{
    public interface IMission : IComparable
    {
        int Id { get; }
        int ParentId { get; }
        string Uuid { get; }
        string Name { get; }
        string Description { get; }

        bool IsCompleted();
    }
}