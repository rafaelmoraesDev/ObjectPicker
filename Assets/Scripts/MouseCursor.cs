using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseCursor : MonoBehaviour
{
    [SerializeField] private GameDirector gameDirector;
    [SerializeField] private Image crosshair;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        if (gameDirector.IsFinished)
        {
            crosshair.gameObject.SetActive(false);
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
