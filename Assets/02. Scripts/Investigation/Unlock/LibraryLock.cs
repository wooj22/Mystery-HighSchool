using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LibraryLock : MonoBehaviour
{
    [SerializeField] GameObject terget;

    public void OnTarget()
    {
        if (InvestigationManager.Instance.isGetPhone)
        {
            terget.SetActive(true);
            InvestigationManager.Instance.CheakingLibrary();
            InvestigationUIManager.Instance.setAdviceText("류와 사쿠라가 심하게 싸우고 있는듯 하다.");
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
