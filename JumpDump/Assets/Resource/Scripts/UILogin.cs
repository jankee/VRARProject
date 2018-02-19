using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using GameData;

public class UILogin : MonoBehaviour
{
    //상태 메세지
    public Text stateText;

    //로그인 성공 여부 확인을 위한 Callback
    private Action<bool> signInCallback;

    private void Awake()
    {
        //안드로이드 빌더 초기화
        PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder().Build();
        PlayGamesPlatform.InitializeInstance(config);

        //구글 플레이 로그를 확인 할려면 활성화
        PlayGamesPlatform.DebugLogEnabled = true;

        //구글 플레이 활성화
        PlayGamesPlatform.Activate();

        //Callback 함수 정의
        signInCallback = (bool success) =>
        {
            if (success)
            {
                stateText.text = "SignIn Success";
            }
            else
            {
                stateText.text = "SignIn Fail";
            }
        };
    }

    // Use this for initialization
    private void Start()
    {
        //Social.localUser.Authenticate
        //    (
        //        success =>
        //        {
        //            if (success)
        //            {
        //                print("Authentication successful");

        //                string userInfo = "Username : " + Social.localUser.userName +
        //                "\nUser ID : " + Social.localUser.id +
        //                "\nIsUnderage : " + Social.localUser.underage;

        //                print(userInfo);
        //            }
        //            else
        //            {
        //                print("Authentication failed");
        //            }
        //        }
        //    );

        //SignIn();
    }

    //로그인
    public void SignIn()
    {
        //로그 아웃 상태면 호출
        if (PlayGamesPlatform.Instance.IsAuthenticated() == false)
        {
            PlayGamesPlatform.Instance.Authenticate(signInCallback);

            //업적을 한번 불러 봄
            Social.ReportProgress(GPGSIds.achievement_1, 100F, null);
        }
    }

    public void SignOut()
    {
        if (PlayGamesPlatform.Instance.IsAuthenticated() == true)
        {
            stateText.text = "Bye~";
            PlayGamesPlatform.Instance.SignOut();
        }
    }

    // Update is called once per frame
    public void ShowBoard()
    {
        Social.ShowLeaderboardUI();
    }

    public void ShowAchievement()
    {
        Social.ShowAchievementsUI();
    }
}