using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camerafollow : MonoBehaviour
{
    // 카메라 지정
    //private Camera cam;

    // 플레이어가 멈춰있을 때 카메라자동이동 속도
    public float speed = 0.05f;

    private Coroutine endPosRoutine;

    private Vector3 originPos = new Vector3(8.3f, 23f, -14.5f);

    private Vector3 endPos = new Vector3(6.6f, 23f, -11.5f);

    // 게임 종료 여부
    public static bool IsGameStop = false;

    private Vector3 targetPos;

    //private void Start()
    //{
    //    target = GameObject.Find("Player");
    //}

    //카메라 이동 방법 : RoadGenerator의 자식으로
    public void OriginPosition(Vector3 tmpTarget)
    {
        targetPos = tmpTarget;

        print("targetPos : " + targetPos);

        StartCoroutine(OriginPositionRoutine(targetPos));
    }

    private IEnumerator OriginPositionRoutine(Vector3 tarPos)
    {
        //아래만큼 쉬었다가 실행한다
        yield return new WaitForSeconds(0.2f);

        float timer = 0.25f;

        float coolTime = 0f;

        Vector3 targetPosOrigin = tarPos;

        //타겟의 위치와 카메라 위치값을 더 함
        tarPos += originPos;

        //카메라의 포지션 저장
        Vector3 camPos = this.transform.position;

        while (coolTime < timer)
        {
            coolTime += Time.deltaTime;

            this.transform.position = Vector3.Lerp(camPos, tarPos, coolTime / timer);

            yield return null;
        }

        this.transform.position = tarPos;

        //이유를 모르겠음
        //InputManager.Instance.IsMoved = false;

        //캐릭터가 뒤로 가고 있지 안다면
        //if (!InputManager.Instance.IsStun)
        //{
        if (endPosRoutine != null)
        {
            //우선 움직이면 코투틴이 멈춘다
            StopCoroutine(endPosRoutine);
        }
        //}

        endPosRoutine = StartCoroutine(TimeOutRoutine(targetPosOrigin));
    }

    /// <summary>
    /// 일정 시간 후 카메라가 앞으로 전진하여 캐릭터가 사망을 한다
    /// </summary>
    /// <returns></returns>
    private IEnumerator TimeOutRoutine(Vector3 tarPos)
    {
        yield return new WaitForSeconds(6f);

        print("Origin Pos : " + tarPos);

        tarPos += endPos;

        print("tarPos : " + tarPos);

        Vector3 camPos = this.transform.position;

        float outTimer = 6f;

        float coolTime = 0f;

        while (coolTime < outTimer)
        {
            coolTime += Time.deltaTime;

            this.transform.position = Vector3.Lerp(camPos, tarPos, coolTime / outTimer);

            yield return null;
        }

        this.transform.position = tarPos;
    }
}