using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    private bool isDrag;
    private Transform target;
    private Camera cam;
    private Vector3 screenPos;
    private Vector3 offset;
    private RaycastHit hit;
    private Ray ray;
    [SerializeField] private GameObject[] allTargets;
    private GameObject selected;

    private void Start()
    {
        this.isDrag = false;
        this.cam = Camera.main;
        this.allTargets = GameObject.FindGameObjectsWithTag("Selectable");
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            this.ray = this.cam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(this.ray.origin, this.ray.direction, out this.hit))
            {
                foreach (var obj in this.allTargets)
                {
                    bool interactable = obj.GetComponent<ObjectBehavior>().Interactable;

                    if (this.hit.collider.name == obj.name && interactable)
                    {
                        this.selected = obj;
                        this.selected.GetComponent<Rigidbody>().isKinematic = true;
                        this.target = this.hit.collider.transform;
                        this.screenPos = this.cam.WorldToScreenPoint(this.target.position);
                        Vector3 aux = new Vector3(this.screenPos.x, this.screenPos.y, this.screenPos.z);
                        this.offset = this.target.position - this.cam.ScreenToWorldPoint(aux);
                        this.isDrag = true;
                    }
                }
            }

        }
        else if (Input.GetMouseButtonUp(0) && this.isDrag)
        {
            this.selected.GetComponent<Rigidbody>().isKinematic = false;
            this.isDrag = false;
            this.selected = null;
        }
        else if (this.isDrag)
        {
            Vector3 currentScreenPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, this.screenPos.z);
            Vector3 currentPos = this.cam.ScreenToWorldPoint(currentScreenPos) + this.offset;
            this.target.position = Vector3.Lerp(this.target.position, currentPos, 10 * Time.deltaTime);
        }
    }

}
