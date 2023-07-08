using System;
using UnityEngine;

namespace Sources.Agent
{
    public class AgentProjectile : MonoBehaviour
    {
        public GameObject player;

        private void Awake()
        {
            player = GameObject.Find("Player");
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.collider.gameObject.CompareTag(player.tag))
            {
                Destroy(gameObject);
            }
        }
    }
}