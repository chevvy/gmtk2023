using System;
using System.Collections;
using System.Collections.Generic;
using Sources.Inventory;
using Sources.Player;
using UnityEngine;

public class BlueKey : MonoBehaviour, IKey
{
    public KeyColor KeyColor => KeyColor.Blue;

    public AudioSource keyPickupSfx; 

    private void OnTriggerEnter(Collider other)
    {
        var playerGameObject = other.gameObject;
        if (playerGameObject.CompareTag("Player"))
        {
            var inventory = playerGameObject.GetComponent<Inventory>();
            inventory.AddKey(this);
            keyPickupSfx.Play();
            Destroy(gameObject);
        }
    }
}
