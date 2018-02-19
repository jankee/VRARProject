using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    // 게임 종료 여부 (플래그(On/Off) 변수)
    public static bool IsGameStop = false;

    [SerializeField]
    private GameObject[] characterArray;

    private GameObject player;

    public GameObject Player
    {
        get
        {
            return player;
        }
    }

    public void Start()
    {
        SelectPlayer();
    }

    public void SelectPlayer()
    {
        if (player != null)
        {
            Destroy(player.gameObject);
        }

        int num = PlayerPrefs.GetInt("SELECTPLAYER", 0);

        player = Instantiate(characterArray[num]);

        Player.transform.position = Vector3.zero;
    }

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