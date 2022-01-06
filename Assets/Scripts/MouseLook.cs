using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float MouseSensitivity = 100f;
    public Transform PlayerBody;

    private float xRotation = 0f;
    private Vector3 endPosition;

    [SerializeField] private GameObject table;

    private void Start()
    {
        endPosition = GameObject.FindGameObjectWithTag("Table").transform.position;
    }

    private void Update()
    {
        transform.LookAt(this.table.transform);

        float mouseX = Input.GetAxis("Mouse X") * MouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * MouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        PlayerBody.Rotate(Vector3.up * mouseX);
    }

    public void LookToTable()
    {
        Vector3 interpolatedPosition = Vector3.Lerp(transform.position, endPosition, 2 * Time.deltaTime);
        Camera.main.transform.position = interpolatedPosition;
    }
}
