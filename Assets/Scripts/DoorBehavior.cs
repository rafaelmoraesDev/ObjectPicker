using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBehavior : MonoBehaviour
{
    private Door door;
    [SerializeField] private GameObject push;
    private GameObject player;
    private Outline outline;
    private float distanceToActivate;

    private void Awake()
    {
        this.player = GameObject.FindGameObjectWithTag("Player");
        this.door = GetComponentInChildren<Door>();
        this.outline = GetComponentInChildren<Outline>();
        this.outline.enabled = false;
    }

    void Update()
    {
        this.distanceToActivate = Vector3.Distance(this.push.transform.position, this.player.transform.position);

        if (this.distanceToActivate <= 1.5f)
        {
            this.outline.enabled = true;

            if (Input.GetButtonDown("Fire1"))
            {
                OpenOrCloseDoor();
            }
        }
        else
        {
            this.outline.enabled = false;
        }
    }

    private void OpenOrCloseDoor()
    {
        this.door.isOpen = !this.door.isOpen;
    }
}