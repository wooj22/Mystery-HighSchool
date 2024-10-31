using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CustomSceneManager : MonoBehaviour
{
    /// 씬 이동
    public void OnLoadSceneByName(string sceneName)
    {
        if(sceneName == "Investigation") // 조사->메인 *게임매니저 Dondestroy안되어서 추가
        {
            setLastScene();
        }
        SceneManager.LoadScene(sceneName);
    }

    /// 게임 종료
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
