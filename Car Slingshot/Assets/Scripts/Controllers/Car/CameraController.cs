using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    Vector3 distanceBetweenCarAndCamera;

    private void UpdateCameraPosition(Vector3 carPosition)
    {
        transform.position = carPosition + distanceBetweenCarAndCamera;
    }

    void Start()
    {
        distanceBetweenCarAndCamera = transform.position;

        EventManager.OnCameraUpdate.AddListener(UpdateCameraPosition);
    }

    
}
