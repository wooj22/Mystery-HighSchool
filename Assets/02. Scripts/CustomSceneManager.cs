using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CustomSceneManager : MonoBehaviour
{
    /// ΩÃ±€≈Ê
    public static CustomSceneManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    /// æ¿ ¿Ãµø
    public void OnLoadSceneByName(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    /// ∞‘¿” ¡æ∑·
    public void QuitGame()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;

        #else
        Application.Quit();

        #endif
    }
}
