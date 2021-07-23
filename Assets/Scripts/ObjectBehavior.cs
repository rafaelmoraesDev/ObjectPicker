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
        this.player = GameObject.FindGameObjectWithTag("Player");
        this.outline = this.GetComponent<Outline>();
        this.outline.enabled = false;
    }

    private void Update()
    {
        if (!this.Dispensed)
        {
            this.distanceToSetEnable = Vector3.Distance(this.transform.position, this.player.transform.position);
        }
    }

    private void OnMouseOver()
    {
        if (this.distanceToSetEnable <= 2f && !Dispensed)
        {
            this.outline.enabled = true;
            this.Interactable = true;
        }
    }

    private void OnMouseExit()
    {
        this.outline.enabled = false;
        this.Interactable = false;
    }    
}
