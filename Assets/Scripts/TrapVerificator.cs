using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TrapVerificator : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.GetComponent<TrapPlataform>()) {
            other.gameObject.GetComponent<TrapPlataform>().RunCoroutine();
        }
    }
}
