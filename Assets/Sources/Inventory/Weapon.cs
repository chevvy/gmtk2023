using UnityEngine;

namespace Sources.Inventory
{
    public class Weapon: MonoBehaviour, IWeapon
    {
        public string ChangeAnimationTrigger { get; }
        public string AttackAnimationTrigger { get; }
        public string Name { get; }
        public void Attack()
        {
            Debug.Log("ATTACK NOT HANDLED");
        }
    }
}