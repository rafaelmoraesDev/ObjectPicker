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
        this.score = this.score + elementScore;
        this.scoreText.text = this.score.ToString();

        if (this.score == 60)
        {
            print("acabou");
            this.finishGame.Invoke();

        }
    }
}
