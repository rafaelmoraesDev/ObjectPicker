using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDirector : MonoBehaviour
{
    public bool IsFinished;

    [SerializeField] private GameObject table;
    [SerializeField] private float speed;

    private GameObject player;
    private Camera cam;
    private Vector3 startPosition;
    private Vector3 endPosition;
    private BlackOut blackOut;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        cam = player.GetComponentInChildren<Camera>();
        endPosition = new Vector3(23f, 2.4f, 20.42f);
        blackOut = FindObjectOfType<BlackOut>();
    }

    private void FixedUpdate()
    {
        if (IsFinished)
        {
            StartCoroutine(SetPositionAndLookPointCamera());
        }
    }

    public void SetUpEndCamera()
    {
        DisableScripts();
        IsFinished = true;
    }

    private void DisableScripts()
    {
        player.GetComponent<PlayerMove>().enabled = false;
        cam.GetComponent<MouseLook>().enabled = false;
    }

    IEnumerator SetPositionAndLookPointCamera()
    {
        startPosition = player.transform.position;
        player.transform.position = Vector3.Lerp(startPosition, endPosition, speed * Time.deltaTime);
        player.transform.LookAt(table.transform);
        yield return new WaitForSeconds(2.5f);
        blackOut.FadeIn();
    }

}
