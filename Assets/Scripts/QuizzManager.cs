using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuizzManager : MonoBehaviour
{
    public Text question;
    public Text response1;
    public Text response2;
    public Text response3;
    public Text response4;
    public Text correctOrIncorrect;

    public string[] questions;
    public string[] responsesA;
    public string[] responsesB;
    public string[] responsesC;
    public string[] responsesD;
    public string[] corrects;

    private int idQuestion = 0;
    private bool correct;

    void Start()
    {
        question.text = questions[idQuestion];
        response1.text = responsesA[idQuestion];
        response2.text = responsesB[idQuestion];
        response3.text = responsesC[idQuestion];
        response4.text = responsesD[idQuestion];
    }

    public void Response(string alternative)
    {
        correct = false;
        switch(alternative){
            case "A":
                if(responsesA[idQuestion] == corrects[idQuestion]) {
                    correct = true;
                }
                break;
            case "B":
                if(responsesB[idQuestion] == corrects[idQuestion]) {
                    correct = true;
                }
                break;
            case "C":
                if(responsesC[idQuestion] == corrects[idQuestion]) {
                    correct = true;
                }
                break;
            case "D":
                if(responsesD[idQuestion] == corrects[idQuestion]) {
                    correct = true;
                }
                break;
        }
        if(correct) {
            correctOrIncorrect.text = "Boa! Você acertou!!";
            StartCoroutine(nextQuestionCouroutine());
        }
        else {
            correctOrIncorrect.text = "Você errou! Tente novamente!";
            StartCoroutine(tryAgainCoroutine());
        }
    }

    private IEnumerator nextQuestionCouroutine()
    {
        yield return new WaitForSeconds(2);
        idQuestion++;
        if(idQuestion <= questions.Length - 1) {
            question.text = questions[idQuestion];
            response1.text = responsesA[idQuestion];
            response2.text = responsesB[idQuestion];
            response3.text = responsesC[idQuestion];
            response4.text = responsesD[idQuestion];
        }
        else {
            idQuestion = 0;
            FindObjectOfType<QuizzUI>().QuizzPanelDes();
        }
        if(idQuestion == 5) {
            FindObjectOfType<QuizzUI>().QuizzPanelDes();
        }
        correctOrIncorrect.text = "";
    }

    private IEnumerator tryAgainCoroutine()
    {
        yield return new WaitForSeconds(2);
        correctOrIncorrect.text = "";
    }

}
