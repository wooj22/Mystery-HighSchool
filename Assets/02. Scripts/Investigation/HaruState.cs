using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HaruState : MonoBehaviour
{
    [SerializeField]
    public string[] stateTexts = new string[] {
        "이름 : 하루 \n 설명 : 전교 1등의 엄친아. 피해자와 소꿉친구이다. \n\n 7시까지 학교에서 자습을 하고 공원 산책을 하다 집에 9시에 귀가했다.",
        "이름 : 하루 \n 설명 : 전교 1등의 엄친아. 피해자와 소꿉친구이다. \n\n \"류의 방에서 라이터가 나왔다구요? 아마 켄지의 것일거예요. 걘 불량학생이거든요.\"",
        "이름 : 하루 \n 설명 : 전교 1등의 엄친아. 피해자와 소꿉친구이다. \n\n \'들켰어... 어떡하지!!!!!! 절대 엄마에게 들켜선 안돼...\'"
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
        if (InvestigationManager.Instance.isCheakedRoad)
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
