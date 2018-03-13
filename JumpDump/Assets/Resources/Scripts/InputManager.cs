using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputManager : Photon.MonoBehaviour
{
    //플레이어 담을 변수
    [SerializeField]
    private Player player;

    //마우스 처음 클릭 지점 위치
    private Vector3 startPos;

    //마우스 마지막 클릭 지점 위치
    private Vector3 endPos;

    private string direction;

    //움직이고 있는지 확인 변수
    public bool IsMoved { get; set; }

    public bool IsBakeMoved { get; set; }

    public bool IsStun { get; set; }

    [SerializeField]
    private Camera mainCamera;

    // Use this for initialization
    private void Start()
    {
        IsMoved = false;

        IsBakeMoved = false;

        IsStun = false;
    }

    // Update is called once per fra
    private void Update()
    {
        //print("IsMoved : " + IsMoved);
        //
        if (PhotonNetwork.connected && photonView.isMine)
        {
            if (!GameManager.Instance.IsPaused && EventSystem.current.IsPointerOverGameObject() == false && !IsMoved && !IsStun)
            {
                HandleInput();
            }
        }
    }

    public void FindStartPlayer()
    {
        //if (PhotonNetwork.connected && photonView.isMine)
        //{
        player = GameObject.FindObjectOfType<Player>();
        //}
    }

    //실제 인풋이 들어 오는 함수
    public void HandleInput()
    {
        Ray ray;

        RaycastHit hitInfo;

        if (Input.GetMouseButtonDown(0))
        {
            ray = mainCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hitInfo))
            {
                startPos = new Vector3(hitInfo.point.x, 0, hitInfo.point.z);
            }
        }
        else if (Input.GetMouseButton(0))
        {
            ray = mainCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hitInfo))
            {
                endPos = new Vector3(hitInfo.point.x, 0, hitInfo.point.z);
                float distance = Vector3.Distance(endPos, startPos);
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            ray = mainCamera.ScreenPointToRay(Input.mousePosition);

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

                //캐릭터가 뒤로 가고 있으면 카메라 무브를 실행 안함
                //if (IsBakeMoved == false)
                //{
                //    //카메라 셋팅
                //    mainCamera.GetComponent<Camerafollow>().OriginPosition();
                //}

                player.MoveCharacter("up");
                //roadGene.FindPlayer();
            }
        }
    }

    private void DirectionCheck()
    {
        Vector3 dirPos = endPos - startPos;

        float dirRot = (Mathf.Atan2(dirPos.z, dirPos.x) * Mathf.Rad2Deg) + 180f;

        if (315f <= dirRot || dirRot <= 45f)
        {
            this.transform.localEulerAngles = new Vector3(0, -90, 0);
            player.MoveCharacter("left");
        }
        else if (45f <= dirRot && dirRot <= 135f)
        {
            this.transform.localEulerAngles = new Vector3(0, 180, 0);
            player.MoveCharacter("Back");
        }
        else if (135f <= dirRot && dirRot <= 225f)
        {
            this.transform.localEulerAngles = new Vector3(0, 90, 0);
            player.MoveCharacter("right");
        }
        else if (225f <= dirRot && dirRot <= 315f)
        {
            this.transform.localEulerAngles = new Vector3(0, 0, 0);
            player.MoveCharacter("up");
        }

        //if (IsBakeMoved == false)
        //{
        //    print("실 행");
        //    //카메라 셋팅
        //    mainCamera.GetComponent<Camerafollow>().OriginPosition();
        //}
    }
}