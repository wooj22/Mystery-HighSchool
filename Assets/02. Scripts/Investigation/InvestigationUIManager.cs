using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InvestigationUIManager : MonoBehaviour
{
    // UI
    [SerializeField] Text charactorDescription;
    [SerializeField] Text adviceText;

    // �̱���
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

    // ĳ���� ����
    public void setCharctorText(string text)
    {
        charactorDescription.text = text;
    }

    public void clearCharctorText()
    {
        charactorDescription.text = "";
    }

    // ���� ����
    public void setAdviceText(string text)
    {
        adviceText.text = text;
    }

    public void clearAdviceText()
    {
        adviceText.text = "";
    }
}
