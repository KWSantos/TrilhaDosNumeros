using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    [Header("References")]
    public GameObject explosionEffect;
    private Rigidbody2D rigidbody2D;
    private Animator animator;

    void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Damage() 
    {   
        SFXManager.instance.damageEffect.Play(); 
        animator.Play("player-damage");
        FindObjectOfType<PlayerMoviment>().isLife = false;
        rigidbody2D.velocity = Vector2.zero;
        StartCoroutine(DestroyPlayer());
    }

    private IEnumerator DestroyPlayer()
    {
        yield return new WaitForSeconds(1f);
        FindAnyObjectByType<GameManager>().GameOver();
        Instantiate(explosionEffect, transform.position, transform.rotation);
        Destroy(this.gameObject);
    }
}
