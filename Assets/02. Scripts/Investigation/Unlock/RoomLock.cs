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
            InvestigationUIManager.Instance.setAdviceText("���� ������ �ο���ִµ� �ϴ�");
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
