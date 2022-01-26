using System;
using System.Collections.Generic;

namespace TatmanGames.Missions.Interfaces
{
    public interface IMission : IComparable
    {
        int Id { get; }
        int ParentId { get; }
        string Uuid { get; }
        string Name { get; }
        string Description { get; }
        List<IMissionStep> Steps { get; }

        bool IsCompleted();
    }
}