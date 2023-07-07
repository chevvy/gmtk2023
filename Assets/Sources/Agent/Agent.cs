using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Sources.Agent
{
    public class Agent : MonoBehaviour
    {
        [FormerlySerializedAs("Player")] public GameObject player;

        private void Awake()
        {
            player = GameObject.Find("Player");
        }
        
        private bool IsPlayerInLos()
        {
            var source = transform.position;
            var target = player.transform.position;
            var direction = target - source;
            var layer = player.layer;

            RaycastHit hit;
            if (Physics.Raycast(source, direction, out hit, layer))
            {
                Debug.Log("Ass");
                return true;
            }

            return false;
        }
        
        private void FixedUpdate()
        {
            Debug.Log(IsPlayerInLos() ? "ASS" : "LOS");
        }   
    }
}