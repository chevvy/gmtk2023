using System;
using Sources.Player;
using UnityEngine;

namespace Sources.Agent
{
    public class AgentProjectile : MonoBehaviour
    {
        public GameObject player;
        public int damage = 20;

        private void Awake()
        {
            player = GameObject.Find("Player");
        }

        private void OnCollisionEnter(Collision other)
        {
            if (!other.collider.gameObject.CompareTag(player.tag)) return;
            
            var playerHealth = player.GetComponent<PlayerHealth>();
                
            playerHealth.ReceiveDamage(damage);

            Destroy(gameObject);
        }
    }
}