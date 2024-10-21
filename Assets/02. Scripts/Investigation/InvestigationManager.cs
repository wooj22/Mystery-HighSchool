using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvestigationManager : MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            
            if (Physics.Raycast(ray, out hit))
            {
                GameObject clickedObject = hit.collider.gameObject;
                Debug.Log("Clicked on object: " + clickedObject.name);
            }
        }
    }
}
