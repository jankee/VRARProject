using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // 게임 종료 여부 (플래그(On/Off) 변수)
    public static bool IsGameStop = false;

    //게임 일시 정지
    private void Update()
    {
        // 게임이 종료 상태면
        if (IsGameStop)
        {
            // 이동을 정지함
            Time.timeScale = 0; //게임전체 진행속도
        }
    }
}