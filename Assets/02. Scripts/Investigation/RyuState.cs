using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RyuState : MonoBehaviour
{
    [SerializeField]
    public string[] stateTexts = new string[] {
        "�̸� : ��(������) \n ��� ���� �� 9�� ���ÿ��� ����� ä �߰ߵǾ���."
        };
    public int currentStateNum;


    private void Start()
    {
        currentStateNum = 0;
    }

    public void StateActive()
    {
        InvestigationUIManager.Instance.setCharctorText(stateTexts[currentStateNum]);
    }

    public void UIClear()
    {
        InvestigationUIManager.Instance.clearCharctorText();
    }
}
