using System;
using UnityEngine;

namespace Sources.Agent
{
    public class AgentHealth : MonoBehaviour
    {
        public GameObject agent;
        public int health = 100;

        private void Awake()
        {
            Debug.Assert(null != agent);
        }

        public void ReceiveDamage(int damage)
        {
            health = Math.Max(0, health - damage);
        }
    }
}