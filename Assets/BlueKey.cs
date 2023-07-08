using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueKey : MonoBehaviour, IKey
{
    public KeyColor KeyColor => KeyColor.Blue;

    private void OnTriggerEnter(Collider other)
    {
        var playerGameObject = other.gameObject;
        if (playerGameObject.CompareTag("Player"))
        {
            var inventory = playerGameObject.GetComponent<Inventory>();
            inventory.AddKey(this);
            Destroy(gameObject);
        }
    }
}
