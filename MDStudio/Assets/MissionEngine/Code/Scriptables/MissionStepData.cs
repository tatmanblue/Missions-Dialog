using System;
using TatmanGames.Missions.Interfaces;
using UnityEngine;

namespace TatmanGames.Missions.Scriptables
{
    /// <summary>
    /// TODO: there is a circular reference here that I do not like
    /// </summary>
    [CreateAssetMenu(fileName = "MissionStep", menuName = "Tatman Games/Characters/Mission Step")]
    public class MissionStepData : ScriptableObject, IMissionStep
    {
        #region IMission properties
        public int Id => id;

        public int MissionId => (null == mission ? -1 : mission.Id);

        public int ParentId => (null == parent ? -1: parent.Id);

        public string Uuid => uuid;

        public string Name => missionStepName;

        public string Description => description;

        public bool IsCompleted()
        {
            throw new System.NotImplementedException();
        }
        
        public int CompareTo(object obj)
        {
            throw new System.NotImplementedException();
        }
        #endregion
        
        #region Scriptable data

        [SerializeField] private int id = 1;
        [SerializeField] private MissionStepData parent;
        [SerializeField] private MissionData mission;
        [SerializeField] private string uuid = Guid.NewGuid().ToString();
        [SerializeField] private string missionStepName;
        [SerializeField] private string description;

        #endregion
    }
}