using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CFollowCamera : MonoBehaviour {

    private Transform _target;   // 추적 대상
    public float _smoothTime;   // 이동 보간 시간
    public Vector3 _offset; // 추적 간격

    // Use this for initialization
    void Start () {
        //태그 이름으로 해당 오브젝트를 찾음
        GameObject t = GameObject.FindGameObjectWithTag("Player");
        _target = t.transform;

        transform.position = Vector3.zero;
        transform.position = _target.position;

        // 오프셋 간격으로 카메라의 위치를 변경함
        transform.position = _target.position + _offset;

    }

    private void LateUpdate()
    {
        // 간격 유지 계산
        Vector3 cameraPos = _target.position + _offset;

        // 부드럽게 추적 이동함
        // Vector3.Lerp(현재 위치, 추적 위치, 시간)
        transform.position = Vector3.Lerp(transform.position, cameraPos, _smoothTime);


    }
}
