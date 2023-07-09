﻿using System.Collections;
using UnityEngine;
using UnityEngine.AI;

namespace Sources.Agent
{
    public class AgentKissable: MonoBehaviour
    {
        public GameObject agent;
        public int health = 100;
        public int dmgOnKiss = 50;
        
        public Sprite happySprite;
        public Sprite angrySprite;
        public Sprite dmgSprite;

        private void Awake()
        {
            Debug.Assert(null != agent);
        }

        public void ReceiveKiss()
        {
            takeDmgOnHealth();
            if (agent.GetComponent<Agent>().pacified)
            {
                return;
            }
            
            StartCoroutine(TakeDamageAnim());
        }
        
        private void takeDmgOnHealth()
        {
            health -= dmgOnKiss;
            if (health <= 0)
            {
                agent.GetComponent<Agent>().pacified = true;
                Debug.Log("AGENT PACIFIED and should render sprite");
                var spriteRender = GetComponent<SpriteRenderer>();
                spriteRender.sprite = happySprite;
            
                var navMeshAgent = GetComponent<NavMeshAgent>();
                navMeshAgent.enabled = false;
            }
        }
        
        IEnumerator TakeDamageAnim()
        {
            var spriteRender = GetComponent<SpriteRenderer>();
            spriteRender.sprite = dmgSprite;
        
            yield return new WaitForSeconds(0.5f);

            spriteRender.sprite = angrySprite;
        }
    }
}
