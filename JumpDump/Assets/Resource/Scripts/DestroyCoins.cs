using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyCoins : MonoBehaviour
{
    private UIManager _uiManager;

    [SerializeField]
    private int coinValue;

    private void Start()
    {
        _uiManager = GameObject.FindObjectOfType<UIManager>();
    }

    //플레이어와 충돌 시 코인 제거
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            _uiManager.CoinUp(coinValue);
            Destroy(gameObject);
        }
    }
}