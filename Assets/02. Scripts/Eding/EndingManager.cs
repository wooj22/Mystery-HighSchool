using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndingManager : MonoBehaviour
{
    public Text dialogueText;
    public float typingSpeed = 0.05f; // 타이핑 속도
    public float waitTime = 3.0f; // 한 줄 보여주는 시간

    // 맞췄을 경우
    private string[] trueText = new string[] {
        "범인 지목에.........",
        "성공했습니다!",
        "모범생 하루는 본인의 흡연 사실이 혹시라도 알려질까 두려웠습니다.",
        "소꿉친구인 류는 하루의 가족과도 잘 알고 있습니다.",
        "순간 두려움에 휩쌓인 하루는 저녁 8시, 류의 방에 방문했습니다.",
        "하루는 평범하게 이야기하는 척 하며 컵에 독극물을 뭍히고 돌아갔습니다.",
        "이 사실을 모르는 류는 그 컵으로 물을 마시고 쓰러졌습니다."
    };

    // 틀렸을경우
    private string[] flaseText = new string[] {
        "범인 지목에.........",
        "실패했습니다.",
    };

    private string currentText = "";

    void Start()
    {
        // 결과 확인 (0이면 성공)
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
            // 타이핑
            yield return StartCoroutine(TypeLine(line));
            yield return new WaitForSeconds(waitTime);

            // 지우기
            yield return StartCoroutine(EraseText());
        }

        // 메인화면으로 이동
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
