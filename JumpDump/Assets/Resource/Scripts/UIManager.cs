using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public Text _coinText;

    // 코인점수 증가
    public void CoinUp()
    {
        int score = int.Parse(_coinText.text);

        score += 10;

        _coinText.text = score.ToString();
        //PlayerPrefs.SetInt("COIN", int.Parse(_coinText.text));
    }

    
}
