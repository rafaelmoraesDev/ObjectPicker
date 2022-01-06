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
        isDrag = false;
        cam = Camera.main;
        allTargets = GameObject.FindGameObjectsWithTag("Selectable");
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ray = cam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray.origin, ray.direction, out hit))
            {
                foreach (var obj in allTargets)
                {
                    bool interactable = obj.GetComponent<ObjectBehavior>().Interactable;

                    if (hit.collider.name == obj.name && interactable)
                    {
                        selected = obj;
                        selected.GetComponent<Rigidbody>().isKinematic = true;
                        target = hit.collider.transform;
                        screenPos = cam.WorldToScreenPoint(target.position);
                        Vector3 aux = new Vector3(screenPos.x, screenPos.y, screenPos.z);
                        offset = target.position - cam.ScreenToWorldPoint(aux);
                        isDrag = true;
                    }
                }
            }

        }
        else if (Input.GetMouseButtonUp(0) && isDrag)
        {
            selected.GetComponent<Rigidbody>().isKinematic = false;
            isDrag = false;
            selected = null;
        }
        else if (isDrag)
        {
            Vector3 currentScreenPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPos.z);
            Vector3 currentPos = cam.ScreenToWorldPoint(currentScreenPos) + offset;
            target.position = Vector3.Lerp(target.position, currentPos, 10 * Time.deltaTime);
        }
    }

}
