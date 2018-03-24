using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using GooglePlayGames;
using GooglePlayGames.BasicApi;

public class ConnectManager : MonoBehaviour
{
    [SerializeField]
    private Text msgText;

    [SerializeField]
    private Text gooleMsgText;

    [SerializeField]
    private GameManager gameManager;

    private Action<bool> signInCallback;

    private void Awake()
    {
        //안드로이드 빌더 초기화
        PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder().Build();

        PlayGamesPlatform.DebugLogEnabled = true;

        PlayGamesPlatform.Activate();

        signInCallback = (bool success) =>
        {
            if (success)
            {
                gooleMsgText.text = "로그인 성공";
            }
            else
            {
                gooleMsgText.text = "로그인 실패";
            }
        };

        if (!PhotonNetwork.connected)
        {
            PhotonNetwork.ConnectUsingSettings("v1.0");

            msgText.text = "[정보] 서버 접속 및 로비 생성을 시도함";
        }
    }

    private void Start()
    {
        SignIn();
    }

    private void SignIn()
    {
        if (PlayGamesPlatform.Instance.IsAuthenticated() == false)
        {
            PlayGamesPlatform.Instance.Authenticate(signInCallback);
        }
    }

    private void SignOut()
    {
        if (PlayGamesPlatform.Instance.IsAuthenticated() == true)
        {
            gooleMsgText.text = "로그 아웃!";
            PlayGamesPlatform.Instance.SignOut();
        }
    }

    // Use this for initialization
    public void OnJoinedLobby()
    {
        msgText.text = "[정보] 포톤 클라우드 및 로비접속이 완료 됨";

        PhotonNetwork.JoinOrCreateRoom("Room", new RoomOptions()
        {
            MaxPlayers = 4,
            IsOpen = true,
            IsVisible = true
        }, TypedLobby.Default);

        msgText.text = "[정보] 로비에 생성된 방에 접속을 시도함";
    }

    public void OnJoinedRoom()
    {
        msgText.text = "[정보] 로비에 생성된 방에 접속함";

        gameManager.IsJoinedRoom = true;
    }

    // Update is called once per frame
    public void OnFailedToConnectToPhoton(DisconnectCause errer)
    {
        print("[오류] 포톤 로비에 방 생성 실패함 : " + errer.ToString());
    }

    public void OnPhotonCreateRoomFailed(object[] errer)
    {
        print("[오류] 포톤 로비에 방 생성 실패함 : " + errer[1].ToString());
    }

    public void OnPhotonJoinRoomFailed(object[] errer)
    {
        print("[오류] 포톤 로비에 생성된 방에 접속 실패함 : " + errer[1].ToString());
    }

    public void OnPhotonRamdomJoinFailed(object[] errer)
    {
        print("[오류] 포톤 로비에 생성된 방에 랜덤 접속 실패함 : " + errer[1].ToString());
    }
}