﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinGenerator_road3 : MonoBehaviour {

    public Transform[] createPos;
    public float coinTime = 1.1f;

    public GameObject Coins;
    //public GameObject[] coins;

    private void Start()
    {
        InvokeRepeating("CreateCoins", coinTime, coinTime);
    }


    void CreateCoins()
    {
        int coinIndex = Random.Range(0, createPos.Length);
        Instantiate(Coins, createPos[coinIndex].position, createPos[coinIndex].rotation, this.transform.parent);
    }
}

