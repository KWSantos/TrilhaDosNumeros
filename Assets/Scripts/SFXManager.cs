using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    public static SFXManager instance;
    public AudioSource collectEffect;
    public AudioSource damageEffect;
    public AudioSource jumpEffect;

    void Awake()
    {
        instance = this;
    }
}
