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

    private Player target;

    private void Start()
    {
        //카메라
        //cam = Camera.main;

        target = FindObjectOfType<Player>();
    }

    //카메라 이동 방법 : RoadGenerator의 자식으로
    public void OriginPosition()
    {
        print(" Camera On ");
        if (target != null)
        {
            print(" Camera Start ");
            Vector3 endPos = target.transform.position;

            StartCoroutine(OriginPositionRoutine(endPos));
        }
    }

    private IEnumerator OriginPositionRoutine(Vector3 endPos)
    {
        yield return new WaitForSeconds(0.25f);

        float timer = 0.25f;

        float coolTime = 0f;

        //타겟의 위치와 카메라 위치값을 더 한다
        endPos += originPos;

        Vector3 tmpPos = this.transform.position;

        while (coolTime < timer)
        {
            coolTime += Time.deltaTime;

            this.transform.position = Vector3.MoveTowards(tmpPos, endPos, coolTime / timer);

            yield return null;
        }

        this.transform.position = endPos;

        InputManager.Instance.IsMoved = false;

        if (endPosRoutine != null)
        {
            //우선 움직이면 코투틴이 멈춘다
            StopCoroutine(endPosRoutine);
        }

        endPosRoutine = StartCoroutine(TimeOutRoutine());
    }

    /// <summary>
    /// 일정 시간 후 카메라가 앞으로 전진하여 캐릭터가 사망을 한다
    /// </summary>
    /// <returns></returns>
    private IEnumerator TimeOutRoutine()
    {
        yield return new WaitForSeconds(4f);

        float outTimer = 6f;

        float coolTime = 0f;

        while (coolTime < outTimer)
        {
            coolTime += Time.deltaTime;

            this.transform.position = Vector3.Lerp(originPos, endPos, coolTime / outTimer);

            yield return null;
        }

        this.transform.position = endPos;
    }
}