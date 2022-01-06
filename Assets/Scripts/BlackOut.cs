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
       image = GetComponent<Image>();
       playerMoveScript = FindObjectOfType<PlayerMove>();
       mouseLookScript = FindObjectOfType<MouseLook>();
       playerMoveScript.enabled = false;
       mouseLookScript.enabled = false;
    }

    private void Start()
    {
       image.canvasRenderer.SetAlpha(1.0f);
       FadeOUt();
    }
    private void FadeOUt()
    {
       image.CrossFadeAlpha(0f,timeToFinish, false);
       StartCoroutine(SetMovementPlayerEnabled());
    }

    public void FadeIn()
    {
       image.CrossFadeAlpha(1f,timeToFinish, false);
        StartCoroutine(SetButtonRestartEnable());
    }

    IEnumerator SetMovementPlayerEnabled()
    {
        yield return new WaitForSeconds(timeToFinish);
       playerMoveScript.enabled = true;
       mouseLookScript.enabled = true;
    }

    IEnumerator SetButtonRestartEnable()
    {
        yield return new WaitForSeconds(timeToFinish);
       restartButton.gameObject.SetActive(true);
    }

}
