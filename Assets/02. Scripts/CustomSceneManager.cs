using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CustomSceneManager : MonoBehaviour
{
    /// �� �̵�
    public void OnLoadSceneByName(string sceneName)
    {
        if(sceneName == "Investigation") // ����->���� *���ӸŴ��� Dondestroy�ȵǾ �߰�
        {
            setLastScene();
        }
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
    
    public void setLastScene()
    {
        PlayerPrefs.SetInt("lastScene", 999);
    }
}
