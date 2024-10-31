using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectManager : MonoBehaviour
{
    [SerializeField] GameObject directionalLight;
    [SerializeField] float lightRotationSpeed;

    public void Start()
    {
        PlayerPrefs.SetInt("lastScene", 0);
    }

    private void Update()
    {
        directionalLight.transform.Rotate(transform.up * lightRotationSpeed * Time.deltaTime, Space.Self);
    }
}
