using System;
using System.Collections.Generic;
using TatmanGames.Missions.Interfaces;
using UnityEngine;

namespace TatmanGames.Missions.Scriptables
{
    [CreateAssetMenu(fileName = "Mission", menuName = "Tatman Games/Characters/Mission")]
    public class Mission : ScriptableObject, IMission
    {
        #region IMission properties
        public int Id
        {
            get { return 0; }
        }
        
        public int ParentId
        {
            get { return 0; }
        }

        public string Uuid
        {
            get { return ""; }
        }

        public string Name
        {
            get { return ""; }
        }

        public string Description
        {
            get { return ""; }
        }

        public List<IMissionStep> Steps
        {
            get { return null; }
        }
        
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
        [SerializeField] private Mission parent;
        [SerializeField] private string uuid = Guid.NewGuid().ToString();
        [SerializeField] private string missionName;
        [SerializeField] private string description;
        [SerializeField] private List<MissionStep> steps = new List<MissionStep>();

        #endregion
    }
}