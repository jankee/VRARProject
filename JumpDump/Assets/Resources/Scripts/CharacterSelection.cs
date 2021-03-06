﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelection : Singleton<CharacterSelection>
{
    [SerializeField]
    private GameObject[] characterArray;

    [SerializeField]
    private GameManager gameManager;

    public GameObject[] CharacterArray
    {
        get
        {
            return characterArray;
        }
    }

    [SerializeField]
    private Transform selectRoot;

    private List<GameObject> characterList = new List<GameObject>();

    private int index;

    private void Start()
    {
        index = 0;

        gameManager.MainCamera.enabled = false;

        gameManager.CharacterCamera.enabled = true;

        for (int i = 0; i < characterArray.Length; i++)
        {
            GameObject tmp = Instantiate(characterArray[i], selectRoot.position, Quaternion.identity, selectRoot);

            characterList.Add(tmp);
        }

        //생성된
        for (int i = 0; i < characterList.Count; i++)
        {
            characterList[i].SetActive(false);
        }

        characterList[index].SetActive(true);
    }

    // 왼쪽 선택 버튼
    public void ToggleLeft()
    {
        // Toggle off the current model
        characterList[index].SetActive(false);

        index--; // index -=1; index = index -1;
        if (index < 0)
        {
            index = characterList.Count - 1;
        }

        // Toggle on the new model
        characterList[index].SetActive(true);
    }

    // 오른쪽 선택 버튼
    public void ToggleRight()
    {
        // Toggle off the current model
        characterList[index].SetActive(false);

        index++; // index -=1; index = index -1;
        if (index == characterList.Count)
        {
            index = 0;
        }

        // Toggle on the new model
        characterList[index].SetActive(true);
    }

    // 플레이 버튼
    public void PlayButton()
    {
        PlayerPrefs.SetInt("SELECTPLAYER", index);

        gameManager.StartPlay();

        //자신을 비활성화 한다
        gameObject.SetActive(false);
    }

    // 랜덤 선택 버튼 선택후 바로 시작
    public void RandPicButton()
    {
        int ran = Random.Range(0, characterList.Count);
        index = ran;

        PlayerPrefs.SetInt("SELECTPLAYER", index);

        gameManager.StartPlay();

        //자신을 비활성화 한다
        gameObject.SetActive(false);
    }
}