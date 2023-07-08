using Sources.Agent;
using UnityEngine;

namespace Sources.Inventory
{
    public class AirKissWeapon : Weapon
    {
        public new string Name => "AirKiss";

        public float range = 100;

        public override void Attack()
        {
            var source = gameObject.transform.position;
            var direction = gameObject.transform.forward;
    
            var collided = Physics.Raycast(source, direction, out var hit, range);

            if (collided && hit.collider.gameObject.CompareTag("Agent"))
            {
                var agent = hit.collider.gameObject;
                var kissable = agent.GetComponent<AgentKissable>();
                
                kissable.ReceiveKiss();
            }
        }
    }
}
