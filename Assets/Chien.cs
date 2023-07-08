using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum ChienState
{
    Stunned,
    Angry,
    Happy
}
public class Chien : MonoBehaviour
{
    // we need to pet 2 times the chien to make him happy
    private readonly int _dmgPerPet = 50;

    private ChienState state = ChienState.Angry;
    private int _health = 100;
    
    
    public void Kiss()
    {
        // Move back the agent
        state = ChienState.Stunned;
        // Make animation on agent sprite to show was stunned
        
        // start coroutine to after x sec, go back to ANGRY
    }

    public void Pet()
    {
        var isPettable = state == ChienState.Stunned;
        if (isPettable)
        {
            _health -= _dmgPerPet;
            if (_health <= 0)
            {
                state = ChienState.Happy;
                // Switch sprite to show happy
            }
        }
    }
}
