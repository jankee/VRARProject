using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camerafollow : MonoBehaviour {

    public GameObject playermesh;

    Vector3 shouldPos;
	
	void Update () {

        shouldPos = Vector3.Lerp(gameObject.transform.position, playermesh.transform.position, Time.deltaTime);
        gameObject.transform.position = new Vector3(shouldPos.x, 1, shouldPos.z);
	}
}
