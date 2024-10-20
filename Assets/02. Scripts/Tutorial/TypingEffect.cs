using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TypingEffect : MonoBehaviour
{
    public Text dialogueText;
    public float typingSpeed = 0.05f; // 타이핑 속도
    public float waitTime = 3.0f; // 한 줄 보여주는 시간
    private string[] lines = new string[] {
        "24년 10월 20일 금요일, 저녁 9시경, 류가 자신의 집에서 사망한 채 발견됐다.",
        "사인은 불명이다.",
        "류는 사망 전 친구 3명과 접촉한 것으로 확인되었다.",
        "이들이 주요 용의자로 지목된다.",
        "이제 현장을 조사하고, 사건의 진실을 밝혀야 한다."
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
            // 타이핑
            yield return StartCoroutine(TypeLine(line));
            yield return new WaitForSeconds(waitTime);

            // 지우기
            yield return StartCoroutine(EraseText());
        }

        // 튜토리얼 끝, 메인게임 이동
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
