using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TableBehavior : MonoBehaviour
{
    private ScoreSet scoreSet;
    private void Start()
    {
        this.scoreSet = GameObject.FindObjectOfType<ScoreSet>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject target = collision.gameObject;
        bool interactable = target.GetComponent<ObjectBehavior>().Interactable;
        if (!interactable)
        {
            this.SetOffBehaviors(target);
        }
    }
    private void SetOffBehaviors(GameObject target)
    {
        target.GetComponent<Outline>().enabled = false;
        this.SetNewScore(target);
        target.GetComponent<ObjectBehavior>().Dispensed = true;
    }

    private void SetNewScore(GameObject target)
    {
        if (!target.GetComponent<ObjectBehavior>().Dispensed)
        {
            int score = target.gameObject.GetComponent<ObjectBehavior>().Score;
            this.scoreSet.SetUpScore(score);
        }

    }
}
