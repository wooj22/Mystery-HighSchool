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
            InvestigationUIManager.Instance.setAdviceText("�Ϸ簡 ��踦 �ǿ�� ���� ������ ��Ų�� �ϴ�");
        }
        else
        {
            InvestigationUIManager.Instance.setAdviceText("��ݵǾ��ֽ��ϴ�");
        }
    }

    public void OffTarget()
    {
        terget.SetActive(false);
        InvestigationUIManager.Instance.clearAdviceText();
    }
}
