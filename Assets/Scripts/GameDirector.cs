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
        this.player = GameObject.FindGameObjectWithTag("Player");
        this.cam = player.GetComponentInChildren<Camera>();
        this.endPosition = new Vector3(23f, 2.4f, 20.42f);
        this.blackOut = FindObjectOfType<BlackOut>();
    }

    private void FixedUpdate()
    {
        if (this.IsFinished)
        {
            StartCoroutine(this.SetPositionAndLookPointCamera());
        }
    }

    public void SetUpEndCamera()
    {
        this.DisableScripts();
        this.IsFinished = true;
    }

    private void DisableScripts()
    {
        this.player.GetComponent<PlayerMove>().enabled = false;
        this.cam.GetComponent<MouseLook>().enabled = false;
    }

    IEnumerator SetPositionAndLookPointCamera()
    {
        this.startPosition = this.player.transform.position;
        this.player.transform.position = Vector3.Lerp(this.startPosition, this.endPosition, this.speed * Time.deltaTime);
        this.player.transform.LookAt(this.table.transform);
        yield return new WaitForSeconds(2.5f);
        blackOut.FadeIn();
    }

}
