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
        this.endPosition = GameObject.FindGameObjectWithTag("Table").transform.position;
    }

    private void Update()
    {
        this.transform.LookAt(this.table.transform);

        float mouseX = Input.GetAxis("Mouse X") * this.MouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * this.MouseSensitivity * Time.deltaTime;

        this.xRotation -= mouseY;
        this.xRotation = Mathf.Clamp(this.xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(this.xRotation, 0f, 0f);
        this.PlayerBody.Rotate(Vector3.up * mouseX);

    }

    public void LookToTable()
    {
        Vector3 interpolatedPosition = Vector3.Lerp(this.transform.position, this.endPosition, 2 * Time.deltaTime);
        Camera.main.transform.position = interpolatedPosition;
    }
}
