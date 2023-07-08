using System;
using UnityEngine;

namespace Sources.Player
{
    public class PlayerHealth : MonoBehaviour
    {
        private const int MaxHealth = 100;
        private const int MinHealth = 0;
        
        public int health = MaxHealth;

        public void ReceiveDamage(int damage)
        {
            health = Math.Max(MinHealth, health - damage);
            
            Debug.Log("New Health: " + health);
        }

        public void ReceiveHealing(int heal)
        {
            health = Math.Min(MaxHealth, health + heal);
            
            Debug.Log("New Health: " + health);
        }
    }
}