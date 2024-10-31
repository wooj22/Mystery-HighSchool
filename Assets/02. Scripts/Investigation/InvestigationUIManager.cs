using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InvestigationUIManager : MonoBehaviour
{
    // UI
    [SerializeField] Text charactorDescription;
    [SerializeField] Text adviceText;
    [SerializeField] GameObject backButton;

    // 싱글톤
    public static InvestigationUIManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            return;
        }
    }

    // 캐릭터 설명
    public void setCharctorText(string text)
    {
        charactorDescription.text = text;
    }

    public void clearCharctorText()
    {
        charactorDescription.text = "";
    }

    // 보조 설명
    public void setAdviceText(string text)
    {
        adviceText.text = text;
    }

    public void clearAdviceText()
    {
        adviceText.text = "";
    }

    // 메인화면 돌아가기 버튼
    public void SetActiveBack()
    {
        backButton.SetActive(true);
    }
}
