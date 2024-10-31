using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KenjiState : MonoBehaviour
{
    [SerializeField]
    public string[] stateTexts = new string[] {
        "�̸� : ���� \n ���� : �б��� �ҷ��л�. �ٷ� �����ڿ� ���� ���� ��� �Ѵ�. \n\n ��� ���� �ϱ� �� ���� ������ 8�ñ��� �Բ� �־���. �� ������ ������ �𸥴�.",
        "�̸� : ���� \n ���� : �б��� �ҷ��л�. �ٷ� �����ڿ� ���� ���� ��� �Ѵ�. \n\n \"���� ������ �� �����Ͱ� ���Դٱ���? ���� ����߷���.. �� ��Ʈ�� �ΰ�� �� ���ƿ�\"",
        "�̸� : ���� \n ���� : �б��� �ҷ��л�. �ٷ� �����ڿ� ���� ���� ��� �Ѵ�. \n\n \'�ڲ� �� ���ν�Ű���ϱ淡 ¥������ �Ѵ� ġ�� �ߴµ�.. �ƹ��� �𸣰���?\'",
    };
    public int currentStateNum;

    private void Start()
    {
        currentStateNum = 0;
    }

    public void StateActive()
    {
        if (InvestigationManager.Instance.isGetLighter)
        {
            currentStateNum = 1;
        }
        if (InvestigationManager.Instance.isCheakedRoom)
        {
            currentStateNum = 2;
        }
        InvestigationUIManager.Instance.setCharctorText(stateTexts[currentStateNum]);
    }

    public void UIClear()
    {
        InvestigationUIManager.Instance.clearCharctorText();
    }
}
