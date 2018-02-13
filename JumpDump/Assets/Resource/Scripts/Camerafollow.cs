using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camerafollow : MonoBehaviour {

    public GameObject playermesh;

    Vector3 shouldPos;
	
	void Update () {

        shouldPos = Vector3.Lerp(gameObject.transform.position, playermesh.transform.position, Time.deltaTime);
        gameObject.transform.position = new Vector3(shouldPos.x, 1, shouldPos.z);

        // + 지정된 시간에 카마레가 조금씩 위로 올라간다 > 카메라 설정 범위를 넘으면 죽는다.

	}
}
