using System.Collections;
using System.Collections.Generic;
using Sources.Agent;
using UnityEngine;

public class ChienKissable : MonoBehaviour
{
    public GameObject agent;

    private void Awake()
    {
        Debug.Assert(null != agent);
    }

    public void ReceiveKiss()
    {
        // agent.GetComponent<MeshRenderer>().material.color = Color.red;
        // agent.GetComponent<Agent>().pacified = true;
            
        Debug.Log("Dog was kissed <3");
    }
}
