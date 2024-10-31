using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HaruState : MonoBehaviour
{
    [SerializeField]
    public string[] stateTexts = new string[] {
        "�̸� : �Ϸ� \n ���� : ���� 1���� ��ģ��. �����ڿ� �Ҳ�ģ���̴�. \n\n 7�ñ��� �б����� �ڽ��� �ϰ� ���� ��å�� �ϴ� ���� 9�ÿ� �Ͱ��ߴ�.",
        "�̸� : �Ϸ� \n ���� : ���� 1���� ��ģ��. �����ڿ� �Ҳ�ģ���̴�. \n\n \"���� �濡�� �����Ͱ� ���Դٱ���? �Ƹ� ������ ���ϰſ���. �� �ҷ��л��̰ŵ��.\"",
        "�̸� : �Ϸ� \n ���� : ���� 1���� ��ģ��. �����ڿ� �Ҳ�ģ���̴�. \n\n \'���׾�... �����!!!!!! ���� �������� ���Ѽ� �ȵ�...\'"
    };
    public int currentStateNum;
    public bool isEndSurvey;

    private void Start()
    {
        currentStateNum = 0;
        isEndSurvey = false;
    }

    // ĳ���� ���� ��ȭ
    public void StateActive()
    {
        if (InvestigationManager.Instance.isGetLighter)
        {
            currentStateNum = 1;
        }
        if (InvestigationManager.Instance.isCheakedRoad)
        {
            currentStateNum = 2;
            isEndSurvey = true;
        }
        InvestigationUIManager.Instance.setCharctorText(stateTexts[currentStateNum]);
    }

    public void UIClear()
    {
        InvestigationUIManager.Instance.clearCharctorText();
    }
}
