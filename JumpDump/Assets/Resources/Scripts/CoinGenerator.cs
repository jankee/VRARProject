using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinGenerator : Photon.MonoBehaviour
{
    [SerializeField]
    private GameObject Coins;

    [SerializeField]
    private Vector2 randomCoin;

    private int coinPos;

    //private GameObject tmpCoin;

    private void Start()
    {
        int ran = (int)Random.Range(randomCoin.x, randomCoin.y);

        if (ran == 0)
        {
            if (PhotonNetwork.isMasterClient)
            {
                //tmpCoin = PhotonNetwork.Instantiate("Prefabs/" + Coins.name,
                //    new Vector3(coinPos, 0, 0), Quaternion.identity, 0);

                photonView.RPC("SetupCoin", PhotonTargets.AllBuffered);
            }
        }
    }

    [PunRPC]
    private void SetupCoin()
    {
        Transform parentPos = this.transform.GetComponent<Transform>();

        coinPos = Random.Range(-5, 6);

        GameObject tmpCoin = Instantiate(Coins, this.transform);

        //GameObject tmpCoin = PhotonNetwork.Instantiate("Prefabs/" + Coins.name,
        //    new Vector3(coinPos, 0, 0), Quaternion.identity, 0);

        tmpCoin.transform.SetParent(parentPos);

        tmpCoin.transform.localPosition = new Vector3(coinPos, 0, 0);
    }
}