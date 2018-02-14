using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public Text _coinText;
    public Text _clickScoreText;
    public Text _bestClickScoreText;
    public GameObject _select;
    public GameObject _buy;
    public GameObject _score;

    GameManager _gameManager;

    // 코인점수 증가
    public void CoinUp()
    {
        int score = int.Parse(_coinText.text);

        score += 10;

        _coinText.text = score.ToString();
        // 코인 데이터 저장
        PlayerPrefs.SetInt("COIN", int.Parse(_coinText.text));
    }

    public void ScoreUp()
    {

        int clickCount = int.Parse(_clickScoreText.text);
        int bestClickCount = int.Parse(_bestClickScoreText.text);
        clickCount ++;
        // 클릭 카운트가 베스트클릭카운트보다 높을시 갱신
        if (clickCount > bestClickCount)
        {
            _bestClickScoreText.text = clickCount.ToString();
        }
        // 클릭 카운트 표시
        _clickScoreText.text = clickCount.ToString();

        // 클릭, 베스트클릭 점수 저장
        PlayerPrefs.SetInt("Score", int.Parse(_clickScoreText.text));
        PlayerPrefs.SetInt("BestScore", int.Parse(_bestClickScoreText.text));

    }
}
