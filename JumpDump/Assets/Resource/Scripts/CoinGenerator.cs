using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinGenerator : MonoBehaviour
{
    [SerializeField]
    private GameObject Coins;

    private int coinPos;

    private void Start()
    {
        int ran = Random.Range(0, 5);

        if (ran == 0)
        {
            CreateCoins();
        }
    }

    private void CreateCoins()
    {
        coinPos = Random.Range(-5, 6);

        GameObject tmpCoin = Instantiate(Coins, this.transform.parent);

        tmpCoin.transform.localPosition = new Vector3(coinPos, 0, 0);
    }
}