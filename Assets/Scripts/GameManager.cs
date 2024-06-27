using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    
    public float timeForRecharge;
    public float timeForNextLevel;
    public string namOfNextLevel;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)) {
            BackToMenu();
        }
    }

    private void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void GameOver()
    {
        RunCoroutineRecharge();
    }

    public void RunCoroutineRecharge()
    {
        StartCoroutine(RechargeScene());
    }
    private IEnumerator RechargeScene()
    {
        yield return new WaitForSeconds(timeForRecharge);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void RunCoroutineNextLevel()
    {
        StartCoroutine(NextLevelCoroutine());
    }

    private IEnumerator NextLevelCoroutine()
    {
        yield return new WaitForSeconds(timeForNextLevel);
        SceneManager.LoadScene(namOfNextLevel);
    }
}
