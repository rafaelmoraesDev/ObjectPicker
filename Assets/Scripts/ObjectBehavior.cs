using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectBehavior : MonoBehaviour
{
    private Outline outline;
    private GameObject player;
    private float distanceToSetEnable;
    public bool Interactable;
    public bool Dispensed;
    public int Score;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        outline = GetComponent<Outline>();
        outline.enabled = false;
    }

    private void Update()
    {
        if (!Dispensed)
        {
            distanceToSetEnable = Vector3.Distance(transform.position, player.transform.position);
        }
    }

    private void OnMouseOver()
    {
        if (distanceToSetEnable <= 2f && !Dispensed)
        {
            outline.enabled = true;
            Interactable = true;
        }
    }

    private void OnMouseExit()
    {
        outline.enabled = false;
        Interactable = false;
    }    
}
