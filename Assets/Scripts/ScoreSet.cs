using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class ScoreSet : MonoBehaviour
{
    private int score;
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private UnityEvent finishGame;

    public void SetUpScore(int elementScore)
    {
        score = score + elementScore;
        scoreText.text = score.ToString();

        if (score == 60)
        {
            finishGame.Invoke();
        }
    }
}
