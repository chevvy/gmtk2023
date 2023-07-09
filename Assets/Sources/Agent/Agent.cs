using UnityEngine;
using UnityEngine.AI;

namespace Sources.Agent
{
    public class Agent : MonoBehaviour
    {
        public GameObject player;
        private bool _playerSpotted;

        public NavMeshAgent navMeshAgent;

        public GameObject projectilePrefab;
        public float projectileLifetimeInS = 10f;
        public float attackRange = 20f;
        public float attackCooldownInS = 1f;
        private float _attackedLastAtInS;
        
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
            var destination = player.transform.position;

            navMeshAgent.SetDestination(destination);
        }

        private bool IsAttackOnCooldown()
        {
            return _attackedLastAtInS + attackCooldownInS > Time.time;
        }

        private void SetAttackOnCooldown()
        {
            _attackedLastAtInS = Time.time;
        }

        private void SendAttackProjectileTowardsPlayer()
        {
            var projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            var rigidbody = projectile.GetComponent<Rigidbody>();
            var force = Vector3.Normalize(GetDirectionTowardsPlayer()) * 10 + Vector3.Normalize(transform.up) * 5;
            
            rigidbody.AddRelativeForce(force, ForceMode.Impulse);
            
            Destroy(projectile, projectileLifetimeInS);
        }

        private void AttackPlayer()
        {
            if (IsAttackOnCooldown() || pacified) return;
            SetAttackOnCooldown();
            SendAttackProjectileTowardsPlayer();
        }
    }
}