using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClueUIOnOff : MonoBehaviour
{
    [SerializeField] List<GameObject> clueValueLists;

    public void OnValue()
    {
        int lastScene = PlayerPrefs.GetInt("lastScene");
        if (lastScene == 999)
        {
            clueValueLists[0].SetActive(true);
            for (int i = 1; i < clueValueLists.Count; i++)
            {
                clueValueLists[i].SetActive(false);
            }
        }  
    }

}
