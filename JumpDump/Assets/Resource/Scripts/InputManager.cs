using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    //플레이어 담을 변수
    private Player player;

    //마우스 처음 클릭 지점 위치
    private Vector3 startPos;

    //마우스 마지막 클릭 지점 위치
    private Vector3 endPos;

    private string direction;

    private RoadGenerator roadGene;

    // Use this for initialization
    private void Start()
    {
        if (player == null)
        {
            player = GameObject.FindObjectOfType<Player>();
        }

        if (roadGene == null)
        {
            roadGene = GameObject.FindObjectOfType<RoadGenerator>();
        }
    }

    // Update is called once per frame
    private void Update()
    {
        HandleInput();
    }

    //실제 인풋이 들어 오는 함수
    public void HandleInput()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hitInfo;

        if (Input.GetMouseButtonDown(0))
        {
            //마우스가 누른다
            print("마우스가 누른다");

            if (Physics.Raycast(ray, out hitInfo))
            {
                startPos = new Vector3(hitInfo.point.x, 0, hitInfo.point.z);
            }
        }
        else if (Input.GetMouseButton(0))
        {
            //마우스 거리가 0.5이상 드레그 중인가
            print("마우스 드레그 중인가");

            if (Physics.Raycast(ray, out hitInfo))
            {
                endPos = new Vector3(hitInfo.point.x, 0, hitInfo.point.z);
                float distance = Vector3.Distance(endPos, startPos);

                if (distance > 0.2)
                {
                    if (Input.GetMouseButtonUp(0))
                    {
                    }
                    return;
                }
                else
                {
                }
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            if (Physics.Raycast(ray, out hitInfo))
            {
                endPos = new Vector3(hitInfo.point.x, 0, hitInfo.point.z);

                float distance = Vector3.Distance(endPos, startPos);

                if (distance > 1)
                {
                    Debug.DrawRay(ray.origin, ray.direction * 100f, Color.yellow);

                    DirectionCheck();

                    return;
                }

                player.MoveCharacter("up");
                roadGene.RoadDirection("up");
                //플레이어에 앞으로 한칸을 이동 시킨다
                print("한칸 앞으로");
            }
            //마우스를 띄였을 때
            print("마우스를 띄였을 때");
        }
    }

    private void DirectionCheck()
    {
        Vector3 dirPos = endPos - startPos;

        float dirRot = (Mathf.Atan2(dirPos.z, dirPos.x) * Mathf.Rad2Deg) + 180f;

        print("방향 : " + dirRot);

        if (315f <= dirRot || dirRot <= 45f)
        {
            this.transform.localEulerAngles = new Vector3(0, -90, 0);
            print("왼쪽 : " + dirRot);
            player.MoveCharacter("left");
            roadGene.RoadDirection("left");
        }
        else if (45f <= dirRot && dirRot <= 135f)
        {
            this.transform.localEulerAngles = new Vector3(0, 180, 0);
            print("아래 : " + dirRot);
            player.MoveCharacter("down");
            roadGene.RoadDirection("down");
        }
        else if (135f <= dirRot && dirRot <= 225f)
        {
            this.transform.localEulerAngles = new Vector3(0, 90, 0);
            print("오른쪽 : " + dirRot);
            player.MoveCharacter("right");
            roadGene.RoadDirection("right");
        }
        else if (225f <= dirRot && dirRot <= 315f)
        {
            this.transform.localEulerAngles = new Vector3(0, 0, 0);
            print("위쪽 : " + dirRot);
            player.MoveCharacter("up");
            roadGene.RoadDirection("up");
        }
    }
}