using Sources.Agent;
using UnityEngine;

namespace Sources.Inventory
{
    public class PetWeapon : Weapon
    {
        public new string Name => "Pet";
        
        public float range = 5;
        
        public override void Attack()
        {
            var source = gameObject.transform.position;
            var direction = gameObject.transform.forward;
    
            var collided = Physics.Raycast(source, direction, out var hit, range);

            if (collided && hit.collider.gameObject.CompareTag("Agent"))
            {
                var agent = hit.collider.gameObject;
                var pettable = agent.GetComponent<AgentPettable>();
                
                pettable.ReceivePetting();
            }
        }
    }
}
