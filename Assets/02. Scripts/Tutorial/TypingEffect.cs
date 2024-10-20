using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TypingEffect : MonoBehaviour
{
    public Text dialogueText;
    public float typingSpeed = 0.05f; // Ÿ���� �ӵ�
    public float waitTime = 3.0f; // �� �� �����ִ� �ð�
    private string[] lines = new string[] {
        "24�� 10�� 20�� �ݿ���, ���� 9�ð�, ���� �ڽ��� ������ ����� ä �߰ߵƴ�.",
        "������ �Ҹ��̴�.",
        "���� ��� �� ģ�� 3��� ������ ������ Ȯ�εǾ���.",
        "�̵��� �ֿ� �����ڷ� ����ȴ�.",
        "���� ������ �����ϰ�, ����� ������ ������ �Ѵ�."
    };

    private string currentText = "";

    void Start()
    {
        StartCoroutine(ShowTextByLine());
    }

    IEnumerator ShowTextByLine()
    {
        foreach (string line in lines)
        {
            // Ÿ����
            yield return StartCoroutine(TypeLine(line));
            yield return new WaitForSeconds(waitTime);

            // �����
            yield return StartCoroutine(EraseText());
        }

        // Ʃ�丮�� ��, ���ΰ��� �̵�
        yield return new WaitForSeconds(3f);
        GameObject.Find("SceneManager").GetComponent<CustomSceneManager>().OnLoadSceneByName("MainGame");
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
