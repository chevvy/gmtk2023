using UnityEngine;

namespace Sources.Inventory
{
    public class Weapon: MonoBehaviour, IWeapon
    {
        public string Name { get; }
        public void Attack()
        {
            Debug.Log("ATTACK NOT HANDLED");
        }
    }
}