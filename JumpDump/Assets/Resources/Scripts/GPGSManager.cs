﻿using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using GooglePlayGames;
using GooglePlayGames.BasicApi;

public class GPGSManager : MonoBehaviour

{
    public Text stateText;                  // 상태 메세지
    private Action<bool> signInCallback;    // 로그인 성공 여부 확인을 위한 Callback 함수

    private void Awake()
    {
        // 안드로이드 빌더 초기화
        PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder().Build();
        PlayGamesPlatform.InitializeInstance(config);

        // 구글 플레이 로그를 확인할려면 활성화
        PlayGamesPlatform.DebugLogEnabled = true;

        // 구글 플레이 활성화
        PlayGamesPlatform.Activate();

        // Callback 함수 정의
        signInCallback = (bool success) =>
        {
            if (success)
                stateText.text = "SignIn Success!";
            else
                stateText.text = "SignIn Fail!";
        };
    }

    // 로그인
    public void SignIn()
    {
        // 로그아웃 상태면 호출
        if (PlayGamesPlatform.Instance.IsAuthenticated() == false)
            PlayGamesPlatform.Instance.Authenticate(signInCallback);
    }

    // 로그아웃
    public void SignOut()
    {
        // 로그인 상태면 호출
        if (PlayGamesPlatform.Instance.IsAuthenticated() == true)
        {
            stateText.text = "Bye~!";
            PlayGamesPlatform.Instance.SignOut();
        }
    }
}