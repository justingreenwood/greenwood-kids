using Cinemachine;
using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.UIElements;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera cinamachineCamera;
    [SerializeField] float startRotationSpeed = 2;
    [SerializeField] float zoomRotationSpeed = 1;
    [SerializeField] float startFOV = 40;
    [SerializeField] float zoomFOV = 20;
    [SerializeField] FirstPersonController FPC;
    int rightMouseButton = 1;

    // Start is called before the first frame update

    void ToggleZoom()
    {
        float cinamaCamFOV = cinamachineCamera.m_Lens.FieldOfView;
        if (cinamaCamFOV == startFOV)
        {
            cinamaCamFOV = zoomFOV;
            FPC.RotationSpeed = zoomRotationSpeed;
        }
        else
        {
            cinamaCamFOV = startFOV;
            FPC.RotationSpeed = startRotationSpeed;
        }
        cinamachineCamera.m_Lens.FieldOfView = cinamaCamFOV;
    }

    void Update()
    {


        if (Input.GetMouseButtonDown(rightMouseButton))
        {
            ToggleZoom();
        }

    }

    private void OnDisable()
    {
        cinamachineCamera.m_Lens.FieldOfView = startFOV;
    }
}
