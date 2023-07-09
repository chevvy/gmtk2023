using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
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
    public Sprite happySprite;
    [FormerlySerializedAs("AngrySprite")] public Sprite angrySprite;
    [FormerlySerializedAs("DmgSprite")] public Sprite dmgSprite;

    public int dogHealth = 100;
    public int dmgOnKiss = 50;
    public bool isPacified = false;

    public AudioSource hitMarkAudioSource;
    public AudioSource happySound;

    private void Awake()
    {
        Debug.Assert(null != agent);
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (_shouldApplyForce)
        {
            _rigidbody?.AddForce(Vector3.left * forceWhenPushed, ForceMode.Force);
        }
    }

    public void ReceiveKiss()
    {
        // agent.GetComponent<MeshRenderer>().material.color = Color.red;
        // agent.GetComponent<Agent>().pacified = true;
        takeDmgOnHealth();
        hitMarkAudioSource.Play();
        if (isPacified)
        {
            return;
        }
        StartCoroutine(TakeDamageAnim());
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

    IEnumerator TakeDamageAnim()
    {
        var spriteRender = GetComponent<SpriteRenderer>();
        
        spriteRender.sprite = dmgSprite;
        
        yield return new WaitForSeconds(0.5f);
        
        if (isPacified)
        {
            spriteRender.sprite = happySprite;
            yield break;
        }
        
        spriteRender.sprite = angrySprite;
    }

    public void takeDmgOnHealth()
    {
        dogHealth -= dmgOnKiss;
        if (dogHealth <= 0)
        {
            Pacify();
            Debug.Log("DOG PACIFIED and should render sprite");
            var spriteRender = GetComponent<SpriteRenderer>();
            spriteRender.sprite = happySprite;
            
            var navMeshAgent = GetComponent<NavMeshAgent>();
            navMeshAgent.enabled = false;
            
            happySound.Play();
        }
    }

    private void Pacify()
    {
        isPacified = true;
        agent.GetComponent<ChienAgent>().pacified = true;
    }
}
