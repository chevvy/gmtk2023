using Sources.Player;
using UnityEngine;

namespace Sources.Inventory
{
    public class CoffeeWeapon : Weapon
    {
        public new string Name => "Coffee";
        
        public int charges = 1;
        public int healingFactor = 20;

        public override void Attack()
        {
            if (charges > 0) Consume();
        }

        private void Consume()
        {
            GameObject.Find("Player").GetComponent<PlayerHealth>().ReceiveHealing(healingFactor);
            
            charges--;
        }
    }
}
