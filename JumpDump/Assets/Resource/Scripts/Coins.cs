using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    [SerializeField]
    private int coinValue;

    public int CoinValue
    {
        get
        {
            return coinValue;
        }

        set
        {
            coinValue = value;
        }
    }
}