using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float PlayerCameraDistance { get; set; }

    [SerializeField]
    private Transform cameraTarget;

    private Camera playerCamera;
    private float zoomSpeed = 35f;

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
            playerCamera.fieldOfView = Mathf.Clamp(playerCamera.fieldOfView, 15f, 100f);
        }

        Vector3 newPos = cameraTarget.transform.position;

        transform.position = new Vector3(newPos.x, newPos.y + PlayerCameraDistance, newPos.z - PlayerCameraDistance);
    }
}