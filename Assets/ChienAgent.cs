using System;
using Sources.Player;
using UnityEngine;
using UnityEngine.AI;

namespace DefaultNamespace
{
    public class ChienAgent: MonoBehaviour
    {
        public GameObject player;
        private bool _playerSpotted;

        public NavMeshAgent navMeshAgent;
        
        public float attackRange = 5f;
        public float attackCooldownInS = 1f;
        private float _attackedLastAtInS;
        public int meleeDamage = 25; 

        public uint health = 100;

        public bool pacified = false;

        private void Awake()
        {
            player = GameObject.Find("Player");
            
            Debug.Assert(gameObject.CompareTag("Agent"));
            
            navMeshAgent = GetComponent<NavMeshAgent>();
            navMeshAgent.stoppingDistance = attackRange - 5;
        }
        
        private void FixedUpdate()
        {
            if (!pacified)
            {
                if (IsPlayerSpotted()) NavigateTowardsPlayer();
                if (IsPlayerInRange() && IsPlayerInLos()) AttackPlayer();
            }
        }

        private Vector3 GetDirectionTowardsPlayer()
        {
            var position = transform.position;
            var target = player.transform.position;

            return target - position;
        }
        
        private bool IsPlayerInLos()
        {
            var collided = Physics.Raycast(transform.position, GetDirectionTowardsPlayer(), out var hit, Mathf.Infinity);

            return collided && hit.collider.gameObject.CompareTag(player.tag);
        }

        private bool IsPlayerSpotted()
        {
            return _playerSpotted || IsPlayerInLos();
        }

        private bool IsPlayerInRange()
        {
            var distance = Vector3.Distance(transform.position, player.transform.position);

            return distance <= attackRange;
        }

        private void NavigateTowardsPlayer()
        {

            if (navMeshAgent.isOnNavMesh)
            {
                var destination = player.transform.position;
                navMeshAgent.SetDestination(destination);
            }
        }

        private bool IsAttackOnCooldown()
        {
            return _attackedLastAtInS + attackCooldownInS > Time.time;
        }

        private void SetAttackOnCooldown()
        {
            _attackedLastAtInS = Time.time;
        }

        private void MeleeAttackPlayer()
        {
            // Trigger animation for movement of sprite
            player.GetComponent<PlayerHealth>().ReceiveDamage(meleeDamage);
            Debug.Log("Player damaged by " + meleeDamage);
        }

        private void AttackPlayer()
        {
            if (IsAttackOnCooldown() || pacified) return;
            SetAttackOnCooldown();
            MeleeAttackPlayer();
        }

    }
}