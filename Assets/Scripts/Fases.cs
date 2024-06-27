using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fases : MonoBehaviour
{
    public string fase;
    
    public void LoadGame()
    {
        SceneManager.LoadScene(fase);
    }
}
