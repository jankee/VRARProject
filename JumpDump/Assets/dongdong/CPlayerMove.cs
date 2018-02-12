using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPlayerMove : MonoBehaviour {

    public float _moveSpeed;
    //public float _gravity;
    public float _rotSpeed;
    //private Rigidbody _rigidbody;

    private void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        transform.Translate(Vector3.forward * v * _moveSpeed * Time.deltaTime);
        transform.Rotate(Vector3.up * h * _rotSpeed * Time.deltaTime);

        //_rigidbody.velocity = transform.forward * v * _moveSpeed;
        //_rigidbody.angularVelocity = new Vector3(0f, h * _rotSpeed / 360f * Mathf.PI * 2f, 0f);
    }
}
