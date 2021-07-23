using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlackOut : MonoBehaviour
{
    private Image image;
    private PlayerMove playerMoveScript;
    private MouseLook mouseLookScript;
    [SerializeField] private float timeToFinish;
    [SerializeField] private Button restartButton;
    private void Awake()
    {
        this.image = GetComponent<Image>();
        this.playerMoveScript = FindObjectOfType<PlayerMove>();
        this.mouseLookScript = FindObjectOfType<MouseLook>();
        this.playerMoveScript.enabled = false;
        this.mouseLookScript.enabled = false;
    }

    private void Start()
    {
        this.image.canvasRenderer.SetAlpha(1.0f);
        this.FadeOUt();
    }
    private void FadeOUt()
    {
        this.image.CrossFadeAlpha(0f, this.timeToFinish, false);
        this.StartCoroutine(SetMovementPlayerEnabled());
    }

    public void FadeIn()
    {
        this.image.CrossFadeAlpha(1f, this.timeToFinish, false);
        StartCoroutine(SetButtonRestartEnable());
    }

    IEnumerator SetMovementPlayerEnabled()
    {
        yield return new WaitForSeconds(this.timeToFinish);
        this.playerMoveScript.enabled = true;
        this.mouseLookScript.enabled = true;
    }

    IEnumerator SetButtonRestartEnable()
    {
        yield return new WaitForSeconds(this.timeToFinish);
        this.restartButton.gameObject.SetActive(true);
    }

}
