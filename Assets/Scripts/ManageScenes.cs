using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManageScenes : MonoBehaviour
{
    public void SetGameScene()
    {
        SceneManager.LoadScene("Game");
    }
    public void SetMenuScene()
    {
        SceneManager.LoadScene("Menu");
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif

    }
}
