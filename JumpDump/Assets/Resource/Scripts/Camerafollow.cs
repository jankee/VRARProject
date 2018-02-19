using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camerafollow : Singleton<Camerafollow>
{
    // 카메라 지정
    private Camera cam;

    // 플레이어가 멈춰있을 때 카메라자동이동 속도
    public float speed = 0.05f;

    // 게임 종료 여부
    public static bool IsGameStop = false;

    private Vector3 shouldPos; // 플레이어 이동에 맞게 카메라 함께 이동

    private GameObject Coin;

    private Coroutine moveRoutine;

    //private void Update()
    //{
    //    shouldPos = Vector3.Lerp(this.transform.position, GameManager.Instance.Player.transform.position, Time.deltaTime);
    //    this.transform.position = new Vector3(shouldPos.x, 4, 1);

    //    // 게임이 시작되면
    //    if (IsGameStop)
    //    {
    //        //카메라가 자동으로 앞으로 서서히 이동함
    //        transform.Translate(Vector3.forward * Input.GetAxis("Vertical") * Time.deltaTime * speed);
    //    }

    //    // 카메라 범위 밖으로 플레이어가 닿으면
    //    Ray ray = cam.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));

    //    RaycastHit hit;

    //    if (Physics.Raycast(ray, out hit))
    //        // 게임 종료
    //        if (IsGameStop)
    //        {
    //            // 이동을 정지
    //            Time.timeScale = 0;
    //        }

    //        // 게임 지속
    //        else
    //            print("게임 지속");
    //}

    public void MoveCamera(Vector3 end)
    {
        if (moveRoutine != null)
        {
            StopCoroutine(moveRoutine);

            moveRoutine = null;
        }

        moveRoutine = StartCoroutine(MoveCameraRoutine(end));
    }

    public IEnumerator MoveCameraRoutine(Vector3 end)
    {
        float duration = 0;

        Vector3 start = transform.position;

        end = start + end;

        while (duration < 0.5f)
        {
            duration += 0.02f;

            float perc = duration * 4f;

            transform.position = Vector3.Lerp(start, end, perc);
        }

        yield return null;
    }
}