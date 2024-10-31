using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("GameData")]
    [SerializeField] public int limitTime;
    public int currentTime;

    [Header("Ending")]
    [SerializeField] InputField nameText;
    [SerializeField] GameObject endOb;
    [SerializeField] List<GameObject> elseOffOb;

    [Header("Managers")]
    [SerializeField] private CustomSceneManager _customSceneManager;

    private int ending;

    // �̱���
    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);     // �� ����..?
        }
        else
        {
            Destroy(this.gameObject);
            return;
        }

        // Ÿ�̸�
        currentTime = limitTime;
        StartCoroutine(Timer());
    }

    private void Start()
    {
        // ���ӸŴ��� DonDestroy �ȵǾ �߰�
        ending = PlayerPrefs.GetInt("lastScene");
    }

    IEnumerator Timer()
    {
        while (currentTime > 0)
        {
            currentTime--;
            yield return new WaitForSeconds(1f);
        }
        PegSetting();
    }

    // ������ ���� ����
    public void PegSetting()
    {
        endOb.SetActive(true);
        for(int i=0; i< elseOffOb.Count; i++)
        {
            elseOffOb[i].SetActive(false);
        }
    }

    // ������ �̵�
    public void GoEnding()
    {
        if(nameText.text == "�Ϸ�")
        {
            PlayerPrefs.SetInt("result",0);
        }
        else
        {
            PlayerPrefs.SetInt("result", 1);
        }

        _customSceneManager.OnLoadSceneByName("Ending");
    }
}
