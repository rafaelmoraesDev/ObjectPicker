using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableBehavior : MonoBehaviour
{
    private ScoreSet scoreSet;
    private void Start()
    {
        scoreSet = GameObject.FindObjectOfType<ScoreSet>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject target = collision.gameObject;
        bool interactable = target.GetComponent<ObjectBehavior>().Interactable;
        if (!interactable)
        {
            SetOffBehaviors(target);
        }
    }
    private void SetOffBehaviors(GameObject target)
    {
        target.GetComponent<Outline>().enabled = false;
        SetNewScore(target);
        target.GetComponent<ObjectBehavior>().Dispensed = true;
    }

    private void SetNewScore(GameObject target)
    {
        if (!target.GetComponent<ObjectBehavior>().Dispensed)
        {
            int score = target.gameObject.GetComponent<ObjectBehavior>().Score;
            scoreSet.SetUpScore(score);
        }
    }
}
