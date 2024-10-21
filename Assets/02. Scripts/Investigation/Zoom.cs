using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zoom : MonoBehaviour
{
    [Header("Camera Zoom")]
    [SerializeField] float zoomSpeed = 10f;    // �� �ӵ�
    [SerializeField] float minZoom = 5f;       // �ּ� �� �Ÿ�
    [SerializeField] float maxZoom = 20f;      // �ִ� �� �Ÿ�
    private float distance;                    // ī�޶�� ������Ʈ ������ �Ÿ�

    private void Update()
    {
        CameraZoomInOut();
    }

    /// �� �ξƿ�
    private void CameraZoomInOut()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");

        distance -= scroll * zoomSpeed;
        distance = Mathf.Clamp(distance, minZoom, maxZoom);

        this.transform.Translate(transform.forward * distance);
    }
}
