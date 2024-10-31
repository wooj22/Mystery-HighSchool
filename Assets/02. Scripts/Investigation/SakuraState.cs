using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SakuraState : MonoBehaviour
{
    [SerializeField] public string[] stateTexts = new string[] {
        "�̸� : ����� \n ���� : �������� ����ģ�� \n\n ��� ���� �б� ���� �� 3�ú��� ���� �־���. \n �ֱ� ���� ���̰� ���� �ʾҴٴ� �ҹ��� �ִ�.",
        "�̸� : ����� \n ���� : �������� ����ģ�� \n\n \"���� �ڵ����� ���̾��..? ���� �̺� �뺸���ڸ� ���� �ʹ� ȭ������ ���� ��� ������ ������.. ������ ���� �ƴϿ���!!\"",
        "�̸� : ����� \n ���� : �������� ����ģ�� \n\n \" \'���� �б� ���������� ������ ���� �ٶ��� ����� ��Ű�� ������.. �ƹ��� �𸦰ž�.. ������..\'"
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
        if (InvestigationManager.Instance.isGetPhone)
        {
            currentStateNum = 1;
        }
        if (InvestigationManager.Instance.isCheakedjLibrary)
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
