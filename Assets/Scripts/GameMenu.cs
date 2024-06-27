using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMenu : MonoBehaviour
{
    public GameObject startMenuPanel, creditsMenuPanel, faseMenuPanel, howToPlayPanel;

    public void CreditsPanel()
    {
        startMenuPanel.SetActive(false);
        creditsMenuPanel.SetActive(true);
    }

    public void FaseMenu()
    {
        startMenuPanel.SetActive(false);
        faseMenuPanel.SetActive(true);
    }

    public void HowToPlayMenu()
    {
        startMenuPanel.SetActive(false);
        howToPlayPanel.SetActive(true);
    }
    public void StartMenuFromFase()
    {
        faseMenuPanel.SetActive(false);
        startMenuPanel.SetActive(true);
    }

    public void StartMenuFromCredits()
    {
        creditsMenuPanel.SetActive(false);
        startMenuPanel.SetActive(true);
    }

    public void StartMenuFromHowToPlay()
    {
        howToPlayPanel.SetActive(false);
        startMenuPanel.SetActive(true);
    }
    
}
