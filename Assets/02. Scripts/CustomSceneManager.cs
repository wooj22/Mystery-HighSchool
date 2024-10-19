using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CustomSceneManager : MonoBehaviour
{
    /// �� �̵�
    public void OnLoadSceneByName(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    /// ���� ����
    public void QuitGame()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;

        #else
        Application.Quit();

        #endif
    }
}
