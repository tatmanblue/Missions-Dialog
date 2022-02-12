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
    public class NPCSpawnController : MonoBehaviour
    {
        private void Awake()
        {
            if (null == NPCServiceLocator.Instance.Engine)
                NPCServiceLocator.Instance.Engine = new NPCEngine();

            INpcEngine engine = NPCServiceLocator.Instance.Engine;
            
            GameObject[] respawns = GameObject.FindGameObjectsWithTag(engine?.SpawnTag);
            if (null == respawns)
                return;
            
            Debug.Log($"found {respawns?.Length} spawn points");
            foreach (GameObject pointData in respawns)
            {
                NPCSpawnPoint data = pointData.GetComponent<NPCSpawnPoint>();
                if (null == data)
                {
                    Debug.Log("failed to find INPCSpawnData");
                    continue;
                }
                
                Debug.Log($"Spawning {data.Data.Id}");
                // Instantiate(data.Data.NPCAvatar, pointData.transform.position, pointData.transform.rotation);
                engine?.Instantiate(pointData, data);
            }
        }
    }
}
