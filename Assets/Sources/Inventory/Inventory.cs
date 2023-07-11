using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace Sources.Inventory
{
    public class Inventory : MonoBehaviour
    {
        public Weapon[] weapons = new Weapon[] {};
        
        private IWeapon _selectedWeapon;

        private HashSet<KeyColor> _keys = new HashSet<KeyColor>();

        public Animator animator;

        private static readonly int Attack = Animator.StringToHash("Attack");
        private static readonly int Swap = Animator.StringToHash("Swap");
        private static readonly int WeaponIndex = Animator.StringToHash("WeaponIndex");

        public AudioSource activateKey;

        public bool displayDebugInfo = false;

        // Start is called before the first frame update
        void Start()
        {
            if (weapons.Length != 0)
            {
                _selectedWeapon = weapons[0];
            }
        }

        public void OnChangeWeapon(int weaponIndex)
        {
            if (weaponIndex >= weapons.Length) return;
        
            _selectedWeapon = weapons[weaponIndex];
        
            var adjustedIndex = weaponIndex + 1;
        
            animator.SetInteger(WeaponIndex, adjustedIndex);
            animator.SetTrigger(Swap);
        }

        public void OnInteractWithWeapon()
        {
            _selectedWeapon?.Attack();
            animator.SetTrigger(Attack);
            
            DisplayDebugMessage("[INVENTORY] attacked with weapon with name" + _selectedWeapon?.Name);
        }

        public void AddKey(IKey key)
        {
            if (_keys.Contains(key.KeyColor))
            {
                return;
            }
            _keys.Add(key.KeyColor);
            DisplayDebugMessage("Acquired" + key.KeyColor);
        }

        public bool HasKey(KeyColor color) => _keys.Contains(color);

        public void RemoveKey(KeyColor color)
        {
            if (!HasKey(color)) return;
            activateKey.Play();
        
            _keys.Remove(color);
            DisplayDebugMessage("Removed key from inventory");
        }

        private void DisplayDebugMessage(string debugMsg)
        {
            if (!displayDebugInfo)
            {
                return;
            }
            
            Debug.Log("[INVENTORY]" + debugMsg);
        }
    }
}
