using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueKey : MonoBehaviour, IKey
{
    public GameObject player;
    public KeyColors KeyColor => KeyColors.blue;
    
    private void OnEnable()
    {
        if (player == null)
        {
            Debug.LogError("Missing reference to player");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        var playerGameObject = other.gameObject;
        if (playerGameObject.CompareTag(playerGameObject.tag))
        {
            var inventory = playerGameObject.GetComponent<Inventory>();
            inventory.AddKey(this);
            Destroy(gameObject);
        }
    }
}
