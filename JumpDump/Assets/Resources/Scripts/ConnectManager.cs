using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConnectManager : MonoBehaviour
{
    [SerializeField]
    private Text msgText;

    private void Awake()
    {
        if (!PhotonNetwork.connected)
        {
            PhotonNetwork.ConnectUsingSettings("v1.0");

            msgText.text = "[정보] 서버 접속 및 로비 생성을 시도함";
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