using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gambling : MonoBehaviour {

    public Text _coinText;
    public Text _resultCoin;

	// Use this for initialization
	void Start () {
		
	}
	

	public void GambleButtonClick()
    {
        CoinGambleDown();
       int coin = Random.Range(1, 500);
        _resultCoin.text = coin.ToString();
        _coinText.text = coin.ToString();
    }


    public void CoinGambleDown()
    {
        int score = int.Parse(_coinText.text);

        score -= 100;

        _coinText.text = score.ToString();
    }
}
