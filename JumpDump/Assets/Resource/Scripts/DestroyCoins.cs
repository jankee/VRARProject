using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyCoins : MonoBehaviour {

    
    //플레이어와 충돌 시 코인 제거
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }

}
