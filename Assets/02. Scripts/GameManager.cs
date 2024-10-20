using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    /// ΩÃ±€≈Ê, Don'tDestroy
    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        // ΩÃ±€≈Ê ∆–≈œ ±∏«ˆ
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); 
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
