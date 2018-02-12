using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayerMovement : MonoBehaviour {

    public float _speed;
    public float _gravity;
    private Vector3 _moveDirection;

    private CharacterController _cc;

    private void Awake()
    {
        _cc = GetComponent<CharacterController>();
    }

    
    // Update is called once per frame
    void Update()
    {

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        _moveDirection = new Vector3(v, 0f, h);

        if (_moveDirection != Vector3.zero)
        {
            transform.forward = _moveDirection.normalized;
        }

        float s = _speed;

        if (h != 0f && v != 0f)
        {
            float degree = Mathf.Cos(45f * Mathf.Deg2Rad);
            s = s * degree;
        }

        _moveDirection *= s;

        _moveDirection.y -= _gravity;

        _cc.Move(_moveDirection * Time.deltaTime);
    }
}
