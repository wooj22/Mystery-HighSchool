using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainGameUIManager : MonoBehaviour
{
    // 타이머
    [SerializeField] Text timerText;
    [SerializeField] Image timerImage;
    [SerializeField] GameObject ending;
    [SerializeField] GameObject caseBookUI;
    [SerializeField] GameObject switchUI;

    private void Start()
    {
        int lastScene = PlayerPrefs.GetInt("lastScene");    // 게임매니저 Dondestroy안되어서 추가
        Debug.Log(lastScene);
        if (lastScene == 999)
        {
            timerText.gameObject.SetActive(true);
            timerImage.gameObject.SetActive(true);
            ending.SetActive(true);
        }
        else
        {
            timerText.gameObject.SetActive(false);
            timerImage.gameObject.SetActive(false);
            ending.SetActive(false);
        }

        InvokeRepeating(nameof(UpdateTimerUI), 0, 1f);
    }

    // 타이머
    public void UpdateTimerUI()
    {
        int minutes = Mathf.FloorToInt(GameManager.Instance.currentTime / 60);
        int seconds = Mathf.FloorToInt(GameManager.Instance.currentTime % 60);
        timerText.text = $"{minutes:00}:{seconds:00}";
    }

    // 사건수첩 On
    public void CaseBookOn()
    {
        caseBookUI.SetActive(true);
        switchUI.SetActive(false);
    }

    // 사건수첩 Off
    public void CaseBookOff()
    {
        caseBookUI.SetActive(false);
        switchUI.SetActive(true);
    }
}
