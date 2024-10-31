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
            InvestigationUIManager.Instance.setAdviceText("���� ����� ���ϰ� �ο�� �ִµ� �ϴ�.");
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
