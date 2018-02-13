using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    private UIManager _uiManager;

	void Start () {
        _uiManager = GameObject.Find("UIManager").GetComponent<UIManager>();
	}

    // 코인과 충돌지 코인 획득과 코인파괴
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Coin")
        {
            // 스코어 1추가
            _uiManager.CoinUp();
            // 보너스 사운드 재생
            // 코인 삭제
            Destroy(collision.gameObject);
            // 
        }
    }
}
