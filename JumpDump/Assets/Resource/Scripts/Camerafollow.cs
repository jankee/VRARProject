using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camerafollow : MonoBehaviour
{
    public GameObject playerMesh;

    private Vector3 shouldPos;

    private GameObject Coin;

    private void Update()
    {
        //shouldPos = Vector3.Lerp(this.transform.position, playerMesh.transform.position, Time.deltaTime);
        //this.transform.position = new Vector3(shouldPos.x, 4, 1
        //    );

        // + 지정된 시간에 카마레가 조금씩 위로 올라간다 > 카메라 설정 범위를 넘으면 죽는다.
    }
}