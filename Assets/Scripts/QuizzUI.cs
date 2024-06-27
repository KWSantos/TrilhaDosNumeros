using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizzUI : MonoBehaviour
{
    public static QuizzUI Instance;
    public GameObject quizzPanel, tripPanel, startPanel;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void StartPanelActive()
    {
        startPanel.SetActive(true);
        FindObjectOfType<PlayerMoviment>().canMove = false;
        FindObjectOfType<PlayerMoviment>().playerSpeed = 0f;
        FindObjectOfType<PlayerMoviment>().initialPosition = FindObjectOfType<PlayerMoviment>().transform.position;
    }
    public void QuizzPanelActive()
    {
        startPanel.SetActive(false);
        FindObjectOfType<PlayerMoviment>().canMove = false;
        FindObjectOfType<PlayerMoviment>().playerSpeed = 0f;
        FindObjectOfType<PlayerMoviment>().initialPosition = FindObjectOfType<PlayerMoviment>().transform.position;
        quizzPanel.SetActive(true);
    }

    public void QuizzPanelDes()
    {
        quizzPanel.SetActive(false);
        FindObjectOfType<PlayerMoviment>().canMove = true;
        FindObjectOfType<PlayerMoviment>().playerSpeed = 9f;
    }

    public void TripPanel()
    {
        quizzPanel.SetActive(false);
        tripPanel.SetActive(true);
    }

    public void TripToQuiz()
    {
        tripPanel.SetActive(false);
        quizzPanel.SetActive(true);
    }
}
