using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SakuraState : MonoBehaviour
{
    [SerializeField] public string[] stateTexts = new string[] {
        "이름 : 사쿠라 \n 설명 : 피해자의 여자친구 \n\n 사건 당일 학교 조퇴 후 3시부터 집에 있었다. \n 최근 류와 사이가 좋지 않았다는 소문이 있다.",
        "이름 : 사쿠라 \n 설명 : 피해자의 여자친구 \n\n \"류의 핸드폰을 보셨어요..? 그의 이별 통보문자를 보고 너무 화가나서 욕을 계속 보내긴 했지만.. 범인은 제가 아니예요!!\"",
        "이름 : 사쿠라 \n 설명 : 피해자의 여자친구 \n\n \" \'오늘 학교 도서관에서 류에게 내가 바람핀 사실을 들키긴 했지만.. 아무도 모를거야.. 무서워..\'"
    };
    public int currentStateNum;
    public bool isEndSurvey;

    private void Start()
    {
        currentStateNum = 0;
        isEndSurvey = false;
    }

    // 캐릭터 상태 변화
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
