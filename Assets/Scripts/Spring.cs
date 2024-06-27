using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Spring : MonoBehaviour
{
    public float springForce;
    private Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player")) {
            SFXManager.instance.jumpEffect.Play();
            animator.Play("spring-jump-animation");
            other.GetComponent<PlayerMoviment>().ImpulsePlayer(springForce);
        }
    }
}
