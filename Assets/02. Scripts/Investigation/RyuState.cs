using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RyuState : MonoBehaviour
{
    [SerializeField]
    public string[] stateTexts = new string[] {
        "이름 : 류(피해자) \n 사건 당일 밤 9시 자택에서 사망한 채 발견되었다."
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
