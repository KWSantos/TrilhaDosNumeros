using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Collects : MonoBehaviour
{
    
    public GameObject explosionEffect;
    void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player")) {
            
            SFXManager.instance.collectEffect.Play();
            Instantiate(explosionEffect, transform.position, transform.rotation);
            Destroy(this.gameObject);
        }
    }
}
