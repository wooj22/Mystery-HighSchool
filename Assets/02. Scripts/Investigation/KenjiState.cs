using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KenjiState : MonoBehaviour
{
    [SerializeField]
    public string[] stateTexts = new string[] {
        "이름 : 켄지 \n 설명 : 학교의 불량학생. 근래 피해자와 종종 같이 놀곤 한다. \n\n 사건 당일 하교 후 류의 집에서 8시까지 함께 있었다. 그 이후의 행적은 모른다.",
        "이름 : 켄지 \n 설명 : 학교의 불량학생. 근래 피해자와 종종 같이 놀곤 한다. \n\n \"류의 집에서 제 라이터가 나왔다구요? 언제 떨어뜨렸지.. 아 노트도 두고온 것 같아요\"",
        "이름 : 켄지 \n 설명 : 학교의 불량학생. 근래 피해자와 종종 같이 놀곤 한다. \n\n \'자꾸 날 공부시키려하길래 짜증나서 한대 치긴 했는데.. 아무도 모르겠지?\'",
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
