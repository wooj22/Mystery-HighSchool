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

    // 싱글톤
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

    // 조사 마무리 체크
    IEnumerator EndSurveyCheak()
    {
        SakuraState sk = SurveyState[0].GetComponent<SakuraState>();
        HaruState hr = SurveyState[1].GetComponent<HaruState>();
        KenjiState kj = SurveyState[2].GetComponent<KenjiState>();
        while (true)
        {
            if(sk.isEndSurvey && hr.isEndSurvey && kj.isEndSurvey)
            {
                InvestigationUIManager.Instance.setAdviceText("모든 조사를 완료했습니다. 조사를 마치고 범인을 지목하세요.");
                InvestigationUIManager.Instance.SetActiveBack();
                Invoke(nameof(ClearUI), 6f);
                StopCoroutine(inves);
            }
            yield return new WaitForSeconds(3f);    //3초마다 검사 
        }
    }

    // 클릭 감지
    private void ClickDetection()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // 'Clue' 레이어만 검사
            int layerMask = LayerMask.GetMask("Clue");

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
            {
                GameObject clickedObject = hit.collider.gameObject;
                CheakingClue(clickedObject);
                clickedObject.SetActive(false);
            }
        }
    }

    // 단수 수집 체크
    private void CheakingClue(GameObject clue)
    {
        if (clue.CompareTag("Phone"))
        {
            isGetPhone = true;
            InvestigationUIManager.Instance.setAdviceText("휴대폰을 습득했습니다.");
            Invoke(nameof(ClearUI), 1.5f);
        }
        else if (clue.CompareTag("Cup"))
        {
            isGetCup = true;
            InvestigationUIManager.Instance.setAdviceText("컵을 습득했습니다.");
            Invoke(nameof(ClearUI), 1.5f);
        }
        else if (clue.CompareTag("Lighter"))
        {
            isGetLighter = true;
            InvestigationUIManager.Instance.setAdviceText("라이터를 습득했습니다.");
            Invoke(nameof(ClearUI), 1.5f);
        }
        else if (clue.CompareTag("Book"))
        {
            isGetBook = true;
            InvestigationUIManager.Instance.setAdviceText("노트를 습득했습니다.");
            Invoke(nameof(ClearUI), 1.5f);
        }
    }

    private void ClearUI()
    {
        InvestigationUIManager.Instance.clearAdviceText();
    }

    // 씬 조사 체크
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
