using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndingManager : MonoBehaviour
{
    public Text dialogueText;
    public float typingSpeed = 0.05f; // Ÿ���� �ӵ�
    public float waitTime = 3.0f; // �� �� �����ִ� �ð�

    // ������ ���
    private string[] trueText = new string[] {
        "���� ����.........",
        "�����߽��ϴ�!",
        "����� �Ϸ�� ������ �� ����� Ȥ�ö� �˷����� �η������ϴ�.",
        "�Ҳ�ģ���� ���� �Ϸ��� �������� �� �˰� �ֽ��ϴ�.",
        "���� �η��� �۽��� �Ϸ�� ���� 8��, ���� �濡 �湮�߽��ϴ�.",
        "�Ϸ�� ����ϰ� �̾߱��ϴ� ô �ϸ� �ſ� ���ع��� ������ ���ư����ϴ�.",
        "�� ����� �𸣴� ���� �� ������ ���� ���ð� ���������ϴ�."
    };

    // Ʋ�������
    private string[] flaseText = new string[] {
        "���� ����.........",
        "�����߽��ϴ�.",
    };

    private string currentText = "";

    void Start()
    {
        // ��� Ȯ�� (0�̸� ����)
        int result = PlayerPrefs.GetInt("result");
        if (result == 0)
        {
            StartCoroutine(ShowTextByLine(trueText));
        }
        else
        {
            StartCoroutine(ShowTextByLine(flaseText));
        }
        
    }

    IEnumerator ShowTextByLine(string[] texts)
    {
        foreach (string line in texts)
        {
            // Ÿ����
            yield return StartCoroutine(TypeLine(line));
            yield return new WaitForSeconds(waitTime);

            // �����
            yield return StartCoroutine(EraseText());
        }

        // ����ȭ������ �̵�
        yield return new WaitForSeconds(3f);
        GameObject.Find("SceneManager").GetComponent<CustomSceneManager>().OnLoadSceneByName("MainMenu");
    }

    IEnumerator TypeLine(string line)
    {
        for (int i = 0; i < line.Length; i++)
        {
            currentText = line.Substring(0, i + 1);
            dialogueText.text = currentText;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    IEnumerator EraseText()
    {
        while (currentText.Length > 0)
        {
            currentText = currentText.Substring(0, currentText.Length - 1);
            dialogueText.text = currentText;
            yield return new WaitForSeconds(typingSpeed * 0.5f);
        }
    }
}
