using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBehavior : MonoBehaviour
{
    [SerializeField] private GameObject push;
    private Door door;
    private GameObject player;
    private Outline outline;
    private float distanceToActivate;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        door = GetComponentInChildren<Door>();
        outline = GetComponentInChildren<Outline>();
        outline.enabled = false;
    }

    void Update()
    {
        distanceToActivate = Vector3.Distance(push.transform.position, player.transform.position);

        if (distanceToActivate <= 1.5f)
        {
            outline.enabled = true;

            if (Input.GetButtonDown("Fire1"))
            {
                OpenOrCloseDoor();
            }
        }
        else
        {
            outline.enabled = false;
        }
    }

    private void OpenOrCloseDoor()
    {
        door.isOpen = !door.isOpen;
    }
}