using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyableBlock : MonoBehaviour, IInteractable
{
    [SerializeField] 
    public GameObject destroyableResult;

    public Transform explosionPosition;
    
    public float radius = 5.0F;
    public float power = 10.0F;

    public void Interact()
    {
        
        Instantiate(destroyableResult, transform.position, Quaternion.identity);

        Vector3 explosionPos = transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);
        foreach (Collider hit in colliders)
        {
            if (hit.TryGetComponent(out Rigidbody rb))
            {
                StartCoroutine(Explosion(rb));
            }
        }
        
    }

    IEnumerator Explosion(Rigidbody rb)
    {
        rb.AddExplosionForce(power, explosionPosition.position, radius, 5f);
        yield return new WaitForSeconds(0.01f);
        Destroy(gameObject);
    }
}
