using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    // 게임 종료 여부 (플래그(On/Off) 변수)
    public bool IsGameOver { get; set; }

    private bool isPaused = false;

    [SerializeField]
    private Camera mainCamera;

    public Camera MainCamera
    {
        get
        {
            return mainCamera;
        }
        set
        {
            mainCamera = value;
        }
    }

    [SerializeField]
    private Camera characterCamera;

    public Camera CharacterCamera
    {
        get
        {
            return characterCamera;
        }
        set
        {
            characterCamera = value;
        }
    }

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
        IsGameOver = false;

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

        UIManager.Instance.GamePause();
    }

    //게임 일시 정지
    private void Update()
    {
        // 게임이 종료 상태면
        //if (IsGameOver)
        //{
        //    // 이동을 정지함
        //    Time.timeScale = 0; //게임전체 진행속도
        //}
    }

    public void StartPlay()
    {
        UIManager.Instance.StartPanel.SetActive(false);
        //카메라를 바꾸어 준다
        CharacterCamera.enabled = false;

        MainCamera.enabled = true;

        IsGameOver = true;

        UIManager.Instance.GameUnpause();

        SelectPlayer();
    }

    //public void Pause()
    //{
    //    //
    //    isPaused = true;

    //    Time.timeScale = 0;
    //}

    //public void Unpause()
    //{
    //}
}