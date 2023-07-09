using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

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
            
            if (health <= MinHealth)
                InitiateDeathSequence();
        }

        public void ReceiveHealing(int heal)
        {
            health = Math.Min(MaxHealth, health + heal);
            
            Debug.Log("New Health: " + health);
        }

        public void InitiateDeathSequence()
        {
            GameObject.Find("DeathMessage").GetComponent<TextMeshProUGUI>().enabled = true;
            
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}