using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvestigationManager : MonoBehaviour
{
    [Header ("Clue")]
    [SerializeField] public bool isGetPhone;
    [SerializeField] public bool isGetCup;
    [SerializeField] public bool isGetBook;
    [SerializeField] public bool isGetLighter;

    [Header("Servay")]
    [SerializeField] public bool isCheakedCrime;
    [SerializeField] public bool isCheakedjLibrary;
    [SerializeField] public bool isCheakedRoom;
    [SerializeField] public bool isCheakedRoad;
    [SerializeField] List<GameObject> SurveyState;

    private Coroutine inves;

    // �̱���
    public static InvestigationManager Instance { get; private set; }

    private void Awake()
    {
        
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
            return;
        }
    }

    private void Start()
    {
        inves = StartCoroutine(EndSurveyCheak());
    }

    void Update()
    {
        ClickDetection();
    }

    // ���� ������ üũ
    IEnumerator EndSurveyCheak()
    {
        SakuraState sk = SurveyState[0].GetComponent<SakuraState>();
        HaruState hr = SurveyState[1].GetComponent<HaruState>();
        KenjiState kj = SurveyState[2].GetComponent<KenjiState>();
        while (true)
        {
            if(sk.isEndSurvey && hr.isEndSurvey && kj.isEndSurvey)
            {
                InvestigationUIManager.Instance.setAdviceText("��� ���縦 �Ϸ��߽��ϴ�. ���縦 ��ġ�� ������ �����ϼ���.");
                InvestigationUIManager.Instance.SetActiveBack();
                Invoke(nameof(ClearUI), 6f);
                StopCoroutine(inves);
            }
            yield return new WaitForSeconds(3f);    //3�ʸ��� �˻� 
        }
    }

    // Ŭ�� ����
    private void ClickDetection()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // 'Clue' ���̾ �˻�
            int layerMask = LayerMask.GetMask("Clue");

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
            {
                GameObject clickedObject = hit.collider.gameObject;
                CheakingClue(clickedObject);
                clickedObject.SetActive(false);
            }
        }
    }

    // �ܼ� ���� üũ
    private void CheakingClue(GameObject clue)
    {
        if (clue.CompareTag("Phone"))
        {
            isGetPhone = true;
            InvestigationUIManager.Instance.setAdviceText("�޴����� �����߽��ϴ�.");
            Invoke(nameof(ClearUI), 1.5f);
        }
        else if (clue.CompareTag("Cup"))
        {
            isGetCup = true;
            InvestigationUIManager.Instance.setAdviceText("���� �����߽��ϴ�.");
            Invoke(nameof(ClearUI), 1.5f);
        }
        else if (clue.CompareTag("Lighter"))
        {
            isGetLighter = true;
            InvestigationUIManager.Instance.setAdviceText("�����͸� �����߽��ϴ�.");
            Invoke(nameof(ClearUI), 1.5f);
        }
        else if (clue.CompareTag("Book"))
        {
            isGetBook = true;
            InvestigationUIManager.Instance.setAdviceText("��Ʈ�� �����߽��ϴ�.");
            Invoke(nameof(ClearUI), 1.5f);
        }
    }

    private void ClearUI()
    {
        InvestigationUIManager.Instance.clearAdviceText();
    }

    // �� ���� üũ
    public void CheakingCrime()
    {
        isCheakedCrime = true;
    }

    public void CheakingLibrary()
    {
        isCheakedjLibrary = true;
    }

    public void CheakingRoom()
    {
        isCheakedRoom = true;
    }

    public void CheakingRoad()
    {
        isCheakedRoad = true;
    }
}
