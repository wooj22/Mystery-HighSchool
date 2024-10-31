using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header ("GameData")]
    [SerializeField] public int playTime;
    public float currentTime;

    // ½Ì±ÛÅæ
    public static GameManager Instance { get; private set; }

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

        // °ÔÀÓ Å¸ÀÌ¸Ó
        currentTime = playTime;
        StartCoroutine(Timer());
    }

    IEnumerator Timer()
    {
        while (currentTime > 0)
        {
            currentTime--;
            yield return new WaitForSeconds(1f);
        }
    }
}
