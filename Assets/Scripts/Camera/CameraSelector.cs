﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSelector : MonoBehaviour
{
    public static CameraSelector CameraSelectorInstance;

    // Default Camera
    GameObject thirdPersonCamera;

    // All the Other Cameras
    Camera[] cameras = null;

    // Awake is called before the start cycle
    private void Awake()
    {
        if (CameraSelectorInstance == null)
            CameraSelectorInstance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        thirdPersonCamera = GameObject.FindGameObjectWithTag("Third Person Camera");
        cameras = FindObjectsOfType<Camera>();
        DeactivateAllCameras();
    }

    // This function deactivates the Third Person Camera and Activates the given Camera
    public void SwitchToCamera(Camera newCamera)
    {
        thirdPersonCamera.SetActive(false);
        newCamera.enabled = true;
    }

    public void ReturnToThirdView()
    {
        thirdPersonCamera.SetActive(true);
        DeactivateAllCameras();
    }

    private void DeactivateAllCameras()
    {
        foreach(Camera cam in cameras)
        {
            if(!cam.CompareTag("MainCamera"))
                cam.enabled = false;
        }
    }
}