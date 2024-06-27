using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioSource theme;
    private static MusicManager instance;

    void Awake()
    {   
        DontDestroyOnLoad(this.gameObject);
        if(instance != null) {
            Destroy(this.gameObject);
        }
        else {
            instance = this;
        }
    }

    void Start()
    {
        theme.Play();
    }


}
