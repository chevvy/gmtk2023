using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TrainBehavior : MonoBehaviour
{
    Animator animator;
    private GameObject moving;
    private Vector3 previous;
    private PlayerMovement controller;

    void Start()
    {
        animator = GetComponent<Animator>();
        moving = GameObject.Find("Moving");
        previous = moving.transform.position;
        controller = GameObject.Find("Player").GetComponent<PlayerMovement>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        animator.SetTrigger("Go");
    }

    private void FixedUpdate()
    {
        controller.AccumulateTrainMovement(SampleTrainMovement());
    }

    private Vector3 SampleTrainMovement()
    {
        var current = moving.transform.position;

        var movement = current - previous;

        previous = current;

        return movement;
    }
}
