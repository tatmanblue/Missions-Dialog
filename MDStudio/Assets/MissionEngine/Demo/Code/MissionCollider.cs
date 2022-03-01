﻿using System;
using TatmanGames.Common.ServiceLocator;
using TatmanGames.Missions.Interfaces;
using TatmanGames.Missions.Scriptables;
using UnityEngine;

namespace TatmanGames.Missions.Demo
{
    public class MissionCollider : MonoBehaviour
    {
        [SerializeField] private MissionData mission;
        [SerializeField] private MissionStepData step;
        
        private string colliderName = string.Empty;

        private void Awake()
        {
            colliderName = this.gameObject.name;
        }

        private void OnCollisionEnter(Collision collision)
        {
            Debug.Log($"collision.body.name {collision.body.name}");
            Debug.Log($"collision.contacts[0].thisCollider.name {collision.contacts[0].thisCollider.name}");

            IMissionEngine engine = GlobalServicesLocator.Instance.GetService<IMissionEngine>();
            if (null != engine.ActiveStep)
                engine.CompleteActiveMissionStep();
            else
                engine.CompleteActiveMission();
            
            Destroy(this.gameObject);
        }
    }
}