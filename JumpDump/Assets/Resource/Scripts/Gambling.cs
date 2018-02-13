using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Gambling : MonoBehaviour {

    public Text _coinText;
    public Text _resultCoinText;

    private void Start()
    {int value = int.Parse(_coinText.text);
        
    }

    // 뽑기 버튼 실행
    public void GambleButtonClick()
    {
        int value = int.Parse(_coinText.text);
        if (value < 100)
        {
            _resultCoinText.text = "Fail";
            return;
        }
        else
        {
            int ranCoin = Random.Range(1, 500);
            value -= 100;
            _resultCoinText.text = ranCoin.ToString();
            value = value + ranCoin;
            _coinText.text = value.ToString();
        }
    }

   
    // 인터페이스로 돌아감
    /*public void ReturnBotton()
    {
        SceneManager.LoadScene("");
    }*/
}
