using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetOnOff : MonoBehaviour
{
    [SerializeField] GameObject terget;

    public void OnTargetFound()
    {
        terget.SetActive(true);
    }

    public void OnTargetLost()
    {
        terget.SetActive(false);
    }
}
