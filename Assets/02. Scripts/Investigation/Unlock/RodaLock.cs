using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RodaLock : MonoBehaviour
{
    [SerializeField] GameObject terget;

    public void OnTarget()
    {
        if (InvestigationManager.Instance.isGetLighter)
        {
            terget.SetActive(true);
            InvestigationUIManager.Instance.setAdviceText("하루가 담배를 피우는 것을 류에게 들킨듯 하다");
        }
        else
        {
            InvestigationUIManager.Instance.setAdviceText("잠금되어있습니다");
        }
    }

    public void OffTarget()
    {
        terget.SetActive(false);
        InvestigationUIManager.Instance.clearAdviceText();
    }
}
