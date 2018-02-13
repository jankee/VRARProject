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

    private void Update()
    {
        // 플레이어 점프코드
        Bounce bs = thePlayer.transform.parent.GetComponent<Bounce>();
        if (bs.justJump == true)
        {
            anim.SetBool("Jump", false);
        }
        else
        {
            anim.SetBool("Jump", true);
        }

        // 플레이어 회전
        if (Input.GetButtonDown("right"))
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
    }
}
