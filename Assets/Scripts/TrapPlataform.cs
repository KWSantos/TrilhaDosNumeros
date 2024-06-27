using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapPlataform : MonoBehaviour
{
    public float timeForSleep;
    public GameObject explosionEffect;
    public Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void RunCoroutine()
    {
        StartCoroutine(OffPlataform());
    }
    private IEnumerator OffPlataform()
    {
        animator.Play("plataform-des-animation");
        yield return new WaitForSeconds(timeForSleep);
        Instantiate(explosionEffect, transform.position, transform.rotation);
        Destroy(this.gameObject);
    }
}
