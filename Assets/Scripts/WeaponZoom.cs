using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField] Camera cameraFOV;
    [SerializeField] float zoomOutFOV =60f;
    [SerializeField] float zoomedInFOV = 20f;

    bool zoomedInToggle = false;

    private void OnDisable()
    {
        ZoomOut();
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if(zoomedInToggle == false)
            {
                ZoomIn();
            }
            else
            {
                ZoomOut();
            }
        }
    }

    private void ZoomOut()
    {
        zoomedInToggle = false;
        cameraFOV.fieldOfView = zoomOutFOV;
    }

    private void ZoomIn()
    {
        zoomedInToggle = true;
        cameraFOV.fieldOfView = zoomedInFOV;
    }
}
