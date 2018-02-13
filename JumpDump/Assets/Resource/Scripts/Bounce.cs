using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour {

    float lerpTime; // 점프시간
    float currentLerpTime; //현재 점프 시간
    float perc = 1;
 
    //점프가 시작되는 지점, 끝나는지점
    Vector3 startPos;
    Vector3 endPos;

    bool firstInput;
    public bool justJump; //점프를 진행할지 안할지 설정

    void Update()
    {
        if (Input.GetButtonDown("up") || 
            Input.GetButtonDown("down") || 
            Input.GetButtonDown("left") ||
            Input.GetButtonDown("right"))
        {
            if(perc ==1)
            {
                lerpTime = 1;
                currentLerpTime = 0;
                firstInput = true; 
                justJump = true; //점프 여부

            }
        }
        // 시작되는 지점 = 게임오브젝트 위치로 지정
        startPos = gameObject.transform.position;

        // 만약 right버튼을 누르고,시작되는지점이 끝지점일때
        if(Input.GetButtonDown("right") && gameObject.transform.position == endPos)
        {
            // 오른쪽으로 한칸 이동 
            endPos = new Vector3(transform.position.x + 1, transform.position.y, transform.position.z);
        }
        if (Input.GetButtonDown("left") && gameObject.transform.position == endPos)
        {
            // 왼쪽으로 한칸 이동 
            endPos = new Vector3(transform.position.x - 1, transform.position.y, transform.position.z);
        }
        if (Input.GetButtonDown("up") && gameObject.transform.position == endPos)
        {
            // 앞으로 한칸 이동 
            endPos = new Vector3(transform.position.x, transform.position.y, transform.position.z + 1);
        }
        if (Input.GetButtonDown("down") && gameObject.transform.position == endPos)
        {
            // 뒤로 한칸 이동
            endPos = new Vector3(transform.position.x + 1, transform.position.y, transform.position.z -1);
        }

        if(firstInput == true)
        { 
            currentLerpTime += Time.deltaTime;
            perc = currentLerpTime / lerpTime;
            gameObject.transform.position = Vector3.Lerp(startPos, endPos, perc);

            if(perc > 0)
            {
                perc = 1;
            }
            if(Mathf.Round(perc) == 1)
            {
                justJump = false;
            }

        }
    }
}
