using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("GameData")]
    [SerializeField] public int limitTime;
    public int currentTime;

    [Header("Ending")]
    [SerializeField] InputField nameText;
    [SerializeField] GameObject endOb;
    [SerializeField] List<GameObject> elseOffOb;

    [Header("Managers")]
    [SerializeField] private CustomSceneManager _customSceneManager;

    private int ending;

    // 싱글톤
    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);     // 왜 오류..?
        }
        else
        {
            Destroy(this.gameObject);
            return;
        }

        // 타이머
        currentTime = limitTime;
        StartCoroutine(Timer());
    }

    private void Start()
    {
        // 게임매니저 DonDestroy 안되어서 추가
        ending = PlayerPrefs.GetInt("lastScene");
    }

    IEnumerator Timer()
    {
        while (currentTime > 0)
        {
            currentTime--;
            yield return new WaitForSeconds(1f);
        }
        PegSetting();
    }

    // 용의자 지목 시작
    public void PegSetting()
    {
        endOb.SetActive(true);
        for(int i=0; i< elseOffOb.Count; i++)
        {
            elseOffOb[i].SetActive(false);
        }
    }

    // 엔딩씬 이동
    public void GoEnding()
    {
        if(nameText.text == "하루")
        {
            PlayerPrefs.SetInt("result",0);
        }
        else
        {
            PlayerPrefs.SetInt("result", 1);
        }

        _customSceneManager.OnLoadSceneByName("Ending");
    }
}
