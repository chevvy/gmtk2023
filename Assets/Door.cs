using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;


public class Door : MonoBehaviour
{
   [FormerlySerializedAs("requiredKeyColors")] public KeyColor requiredKeyColor;
   [FormerlySerializedAs("animator")] public Animator playerAnimator;   
   [FormerlySerializedAs("Player")] public GameObject player;
   private static readonly int Open = Animator.StringToHash("Open");

   private void Awake()
   {
      if (playerAnimator == null)
      {
         Debug.LogError("Missing animator reference");
      }
      
      player = GameObject.Find("Player");
      
   }

   private void OnTriggerEnter(Collider other)
   {
      if (!other.gameObject.CompareTag(player.tag)) return;
      
      var inventory = other.gameObject.GetComponent<Inventory>();
      if (inventory.HasKey(requiredKeyColor))
      {
         inventory.RemoveKey(requiredKeyColor);
         playerAnimator.SetTrigger(Open);
      }
   }
}
