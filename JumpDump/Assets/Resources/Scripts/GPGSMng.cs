using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using GooglePlayGames.BasicApi.SavedGame;
using System;

public class GPGSMng : Singleton<GPGSMng>
{
    //현제 로그인 중인지 체크
    public bool bLogin
    {
        get;
        set;
    }

    //GPGS를 초기화
    public void InitializeGPGS()
    {
        bLogin = false;

        PlayGamesPlatform.Activate();
    }

    public void LoginCallBackGPGS(bool result)
    {
        bLogin = result;
    }

    public void LogoutGPGS()
    {
        if (Social.localUser.authenticated)
        {
            ((GooglePlayGames.PlayGamesPlatform)Social.Active).SignOut();
            bLogin = false;
        }
    }

    // Use this for initialization
    private string GetNameGPGS()
    {
        if (Social.localUser.authenticated)
        {
            return Social.localUser.userName;
        }
        else
        {
            return null;
        }
    }
}