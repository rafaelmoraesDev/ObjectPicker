using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private float openValueY = 90f;
    [SerializeField] private float closeValueY;
    [SerializeField] private float speed = 2f;
    [SerializeField] private bool facedLeft;
    public bool isOpen;

    private void Update()
    {
        Quaternion qRotation = transform.localRotation;
        float Yvalue = this.closeValueY;
        if (isOpen) Yvalue = this.openValueY;
        Quaternion newQtrn = Quaternion.Euler(qRotation.eulerAngles.x, qRotation.eulerAngles.y, Yvalue);
        transform.localRotation = Quaternion.Slerp(qRotation, newQtrn, Time.deltaTime * this.speed);

    }

}