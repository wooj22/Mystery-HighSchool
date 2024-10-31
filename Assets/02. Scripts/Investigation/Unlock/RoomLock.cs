using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomLock : MonoBehaviour
{
    [SerializeField] GameObject terget;

    public void OnTarget()
    {
        if (InvestigationManager.Instance.isGetBook)
        {
            terget.SetActive(true);
            InvestigationUIManager.Instance.setAdviceText("류와 켄지가 싸우고있는듯 하다");
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
