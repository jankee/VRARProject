using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float PlayerCameraDistance { get; set; }
    public Transform cameraTaget;

    private Camera playerCamera;
    private float zoomSpeed = 25f;

    private void Start()
    {
        PlayerCameraDistance = 12f;
        playerCamera = GetComponent<Camera>();
    }

    private void Update()
    {
        if (Input.GetAxisRaw("Mouse ScrollWheel") != 0)
        {
            float scroll = Input.GetAxis("Mouse ScrollWheel");

            playerCamera.fieldOfView -= scroll * zoomSpeed;

            playerCamera.fieldOfView = Mathf.Clamp(playerCamera.fieldOfView, 15, 100);
        }

        transform.position = new Vector3(cameraTaget.position.x, cameraTaget.position.y + PlayerCameraDistance,
            cameraTaget.position.z - PlayerCameraDistance);
    }
}