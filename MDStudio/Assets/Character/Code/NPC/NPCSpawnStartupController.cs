using System.Collections;
using System.Collections.Generic;
using TatmanGames.Character.Interfaces;
using UnityEngine;

namespace TatmanGames.Character.NPC
{
    /// <summary>
    /// applied to a prefab in a scene, an awake it will
    /// find all prefabs with INPCEngine.SpawnTag set up the NPCs
    /// </summary>
    public class NPCSpawnStartupController : MonoBehaviour, INpcSpawnController
    {
        private INpcEngine engine = null;
        private bool hasLoaded = false;

        private void Update()
        {
            if (hasLoaded == true) return;
            hasLoaded = true;
            StartCoroutine("SpawnNpcs");
        }

        private void SpawnNpcs()
        {
            InitializeDefaults();
            
            engine = NpcServiceLocator.Instance.Engine;
            INpcSpawnController controller = NpcServiceLocator.Instance.Controller;
            
            GameObject[] respawns = controller.GetAllNpcSpawnPoints();
            if (null == respawns)
                return;
            
            Debug.Log($"found {respawns?.Length} spawn points");
            foreach (GameObject pointData in respawns)
            {
                INpcSpawnPoint data = pointData.GetComponent<INpcSpawnPoint>();
                if (null == data)
                {
                    Debug.Log("failed to find INPCSpawnData");
                    continue;
                }
                
                if (false == controller?.CanSpawnAtStartup(data))
                    continue;
                
                Debug.Log($"Spawning {data.Data.Id}");
                engine?.Instantiate(pointData, data);
                
                if (true == data.Data.DestroyPointOnSpawn)
                    Destroy(pointData);
            }
        }

        /// <summary>
        /// consumers should use another means for initializing which implementations they need.
        /// this is here to ensure something works.
        /// </summary>
        private void InitializeDefaults()
        {
            if (null == NpcServiceLocator.Instance.Engine)
                NpcServiceLocator.Instance.Engine = new NPCEngine();

            if (null == NpcServiceLocator.Instance.Controller)
                NpcServiceLocator.Instance.Controller = this;
        }

        public bool CanSpawnAtStartup(INpcSpawnPoint point)
        {
            return true;
        }

        public GameObject[] GetAllNpcSpawnPoints()
        {
            return GameObject.FindGameObjectsWithTag(engine?.SpawnTag);
        }
    }
}
