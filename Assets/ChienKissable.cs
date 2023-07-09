using System;
using System.Collections;
using System.Collections.Generic;
using Sources.Agent;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;

public class ChienKissable : MonoBehaviour
{
    public GameObject agent;

    private bool _shouldApplyForce = false;
    private Rigidbody _rigidbody;
    [FormerlySerializedAs("ForceWhenPushed")] public int forceWhenPushed = 100;
    public float cooldownAfterKiss = 1f;

    private void Awake()
    {
        Debug.Assert(null != agent);
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (_shouldApplyForce)
        {
            _rigidbody.AddForce(Vector3.left * forceWhenPushed, ForceMode.Force);
        }
    }

    public void ReceiveKiss()
    {
        // agent.GetComponent<MeshRenderer>().material.color = Color.red;
        // agent.GetComponent<Agent>().pacified = true;
        StartCoroutine(RigidbodyBounceBack());
        Debug.Log("Dog was kissed <3");
    }

    IEnumerator RigidbodyBounceBack()
    {
        var navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.enabled = false;
        _shouldApplyForce = true;
        _rigidbody.isKinematic = false;
        
        yield return new WaitForSeconds(cooldownAfterKiss);

        _rigidbody.isKinematic = true;
        _shouldApplyForce = false;
        navMeshAgent.enabled = true;
    }
    
    
}
