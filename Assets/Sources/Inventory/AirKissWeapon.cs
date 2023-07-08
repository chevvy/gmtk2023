using System;
using System.Collections;
using System.Collections.Generic;
using Sources.Inventory;
using UnityEditor.Search;
using UnityEngine;
using UnityEngine.Serialization;

public class AirKissWeapon : Weapon
{
    /// <summary>
    /// On va enovyer des squares rouges pour les bis
    /// OnHit, ceux-ci vont detecter si c'est un AI
    /// Si oui, on va changer leur state
    /// </summary>
    
    // public GameObject airKissProjectilePrefab;

    // TODO change values to correct trigger
    public new string ChangeAnimationTrigger => "AirKiss";
    public new string AttackAnimationTrigger => "AttackAirKiss";
    public new string Name => "AirKiss";


    private void Start()
    {
        // if (airKissProjectilePrefab == null)
        // {
        //     Debug.LogError("Missing Reference to airKissPrefab");
        //     return;
        // }
    }

    public void Attack()
    {
        // Vector3 position = transform.position;
        // var airKissInstantiated = Instantiate(airKissProjectilePrefab, transform);
        // airKissInstantiated.transform.Translate(0.0f, 0.0f, 5.0f * Time.deltaTime);
        // // airKissInstantiated.transform.Translate(position * 2.0f * Time.deltaTime);
    }
    
}
