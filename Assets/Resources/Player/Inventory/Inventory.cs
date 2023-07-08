using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;


public class Inventory : MonoBehaviour
{
    private readonly IWeapon[] _weapons = new IWeapon[] {};
    private IWeapon _selectedWeapon;

    private HashSet<KeyColor> _keys = new HashSet<KeyColor>();

    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        if (_weapons.Length != 0)
        {
            _selectedWeapon = _weapons[0];
        }
    }

    public void OnChangeWeapon(int weaponIndex)
    {
        var adjustedIndex = weaponIndex;
        if (adjustedIndex >= _weapons.Length) return;
        
        _selectedWeapon = _weapons[adjustedIndex];
        animator.SetTrigger(_selectedWeapon.ChangeAnimationTrigger);
        Debug.Log("[INVENTORY] Changed to weapon index " + adjustedIndex + ", with name " + _selectedWeapon.Name);
    }

    public void OnInteractWithWeapon()
    {
        _selectedWeapon?.Attack();
        // animator.SetTrigger(_selectedWeapon?.AttackAnimationTrigger);
        Debug.Log("[INVENTORY] attacked with weapon with name" + _selectedWeapon?.Name);
    }

    public void AddKey(IKey key)
    {
        if (_keys.Contains(key.KeyColor))
        {
            return;
        }
        _keys.Add(key.KeyColor);
        Debug.Log("Acquired" + key.KeyColor);
    }

    public bool HasKey(KeyColor color) => _keys.Contains(color);

    public void RemoveKey(KeyColor color)
    {
        if (!HasKey(color)) return;
        
        _keys.Remove(color);
        Debug.Log("[INVENTORY] Removed key from inventory" + color);
    } 

}
