using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zoom : MonoBehaviour
{
    [Header("Camera Zoom")]
    [SerializeField] float zoomSpeed = 10f;    // 줌 속도
    [SerializeField] float minZoom = 5f;       // 최소 줌 거리
    [SerializeField] float maxZoom = 20f;      // 최대 줌 거리
    private float distance;                    // 카메라와 오브젝트 사이의 거리

    private void Update()
    {
        CameraZoomInOut();
    }

    /// 줌 인아웃
    private void CameraZoomInOut()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");

        distance -= scroll * zoomSpeed;
        distance = Mathf.Clamp(distance, minZoom, maxZoom);

        this.transform.Translate(transform.forward * distance);
    }
}
