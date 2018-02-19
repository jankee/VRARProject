using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camerafollow : MonoBehaviour
{
    // 플레이어가 멈춰있을 때 카메라자동이동 속도
    public float speed = 0.5f;

    // 게임 종료 여부
    public static bool IsGameStop = false;

    public GameObject playerMesh;

    private Vector3 shouldPos; // 플레이어 이동에 맞게 카메라 함께 이동

    private GameObject Coin;

    private void Update()
    {
        shouldPos = Vector3.Lerp(this.transform.position, playerMesh.transform.position, Time.deltaTime);
        this.transform.position = new Vector3(shouldPos.x, 4, 1);


        // 게임이 시작되면
        if (IsGameStop) 
        {
            //카메라가 자동으로 앞으로 이동함
            transform.Translate(Vector3.forward * Input.GetAxis("Vertical") * Time.deltaTime * speed);
        }

    }


}