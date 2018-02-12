using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public Vector3 nextDir; // 다음 방향

    public float jumpForce = 100; // 점프하는 힘의 크기

    public float speed = 5; // 점프 속도
    public float speedRot = 100; //회전 속도

    Rigidbody rb;

    public Vector3 curPosition;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        curPosition = transform.position;
    }

    void Update()
    {
        if (transform.position != new Vector3(curPosition.x, transform.position.y, curPosition.z) + nextDir)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(curPosition.x, transform.position.y, curPosition.z) + nextDir, speed * Time.deltaTime);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(nextDir), speedRot * Time.deltaTime);
        }
        else
        {
            nextDir = Vector3.zero;
            curPosition = transform.position;
            curPosition.x = Mathf.Round(curPosition.x);
            curPosition.y = Mathf.Round(curPosition.y);

            if (Input.GetAxisRaw("Horizontal") != 0)
            {
                nextDir.z = -Input.GetAxisRaw("Horizontal");
                Move();
            }
            else if (Input.GetAxisRaw("Vertical") != 0)
            {
                nextDir.z = +Input.GetAxisRaw("Vertical");
                Move();
            }
        }
    }

    void Move()
    {
        rb.AddForce(0, jumpForce, 0);
    }
}
