using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    private UIManager _uiManager;

	// Use this for initialization
	void Start () {
        _uiManager = GameObject.Find("UIManager").GetComponent<UIManager>();
	}

    // 코인과 충돌지 코인 획득과 코인파괴
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Coin")
        {
            _uiManager.CoinUp();
            Destroy(collision.gameObject);
        }
    }
}
