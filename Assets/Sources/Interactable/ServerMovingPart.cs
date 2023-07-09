using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServerMovingPart : MonoBehaviour
{
    Vector3 origin;
    Vector3 target;
    float movementSpeed;
    float interpolation;
    float startingDelay;
    float timer;
    bool goingUp;


    // Start is called before the first frame update
    void Start()
    {
        movementSpeed = Random.Range(0.2f,0.4f);
        origin = transform.position;
        target = origin + new Vector3(0,-32,0);
        goingUp = false;
        startingDelay = Random.Range(0f, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = Vector3.Slerp(origin, target,interpolation);

        if (goingUp && timer >= startingDelay)
        {
            if (interpolation >= 1)
            {
                goingUp = false;
            }
            interpolation = interpolation + movementSpeed * Time.deltaTime;
        }
        else if (!goingUp && timer >= startingDelay)
        {
            if (interpolation <= 0)
            {
                goingUp = true;
            }
            interpolation = interpolation - movementSpeed * Time.deltaTime;
        }
        else if (timer <= startingDelay) 
        { 
        
            timer += Time.deltaTime;
        
        }


    }
}
