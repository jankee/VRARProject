using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPlayerMove : MonoBehaviour {

    Animator anim;
    public GameObject thePlayer; //플레이어 오브젝트

    private void Start()
    {
        //Jump 애니메이터
        anim = gameObject.GetComponent<Animator>();
    }


    // 플레이어 회전
    private void Update()
    {

        Bounce bs = thePlayer.GetComponent<Bounce>();
        if (bs.justJump == true)
        {
            anim.SetBool("Jump", true);
        }
        else
        {
            anim.SetBool("Jump", false);
        }
        if(Input.GetButtonDown("right"))
        {
            gameObject.transform.rotation = Quaternion.Euler(0,90,0);
        }
        if (Input.GetButtonDown("left"))
        {
            gameObject.transform.rotation = Quaternion.Euler(0, -90, 0);
        }
        if (Input.GetButtonDown("up"))
        {
            gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        if (Input.GetButtonDown("down"))
        {
            gameObject.transform.rotation = Quaternion.Euler(0, 180, 0);
        }


        /*float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        transform.Translate(Vector3.forward * v * _moveSpeed * Time.deltaTime);
        transform.Rotate(Vector3.up * h * _rotSpeed * Time.deltaTime);*/

    }
}
