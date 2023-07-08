using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;


public class Inventory : MonoBehaviour
{
    public IWeapon[] Weapons = new IWeapon[] {};
    private IWeapon _selectedWeapon;

    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        if (Weapons.Length != 0)
        {
            _selectedWeapon = Weapons[0];
        }
    }

    public void OnChangeWeapon(int weaponIndex)
    {
        var adjustedIndex = weaponIndex;
        if (adjustedIndex >= Weapons.Length) return;
        
        _selectedWeapon = Weapons[adjustedIndex];
        animator.SetTrigger(_selectedWeapon.ChangeAnimationTrigger);
        Debug.Log("[INVENTORY] Changed to weapon index " + adjustedIndex + ", with name " + _selectedWeapon.Name);
    }

    public void OnInteractWithWeapon()
    {
        _selectedWeapon?.Attack();
        // animator.SetTrigger(_selectedWeapon?.AttackAnimationTrigger);
        Debug.Log("[INVENTORY] attacked with weapon with name" + _selectedWeapon?.Name);
    }
}
