using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainGameUIManager : MonoBehaviour
{
    // 타이머
    [SerializeField] Text timerText;
    [SerializeField] Image timerImage;
    [SerializeField] GameObject caseBookUI;
    [SerializeField] GameObject switchUI;

    private void Start()
    {
        InvokeRepeating(nameof(UpdateTimerUI), 0, 1f);
    }

    // 타이머 업데이트
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
