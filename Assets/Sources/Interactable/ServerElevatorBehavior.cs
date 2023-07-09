using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServerElevatorBehavior : MonoBehaviour
{
    float randomDelay;
    float timer;
    Animator animator;
    public 

    // Start is called before the first frame update
    void Start()
    {
        randomDelay = Random.Range(0f, 6f);
        animator = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timer <= randomDelay) 
        {
            timer = timer + Time.deltaTime;
        }

        else if (timer >= randomDelay) 
        {
            Trigger();
        }
        

    }

    private void Trigger() 
    {

        //animator.SetTrigger("Start");


    }

}
