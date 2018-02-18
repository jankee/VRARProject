using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
    //public Text _coinText;
    //public Text _clickScoreText;
    //public Text _bestClickScoreText;
    [SerializeField]
    private GameObject startPanel;

    [SerializeField]
    private GameObject _selectPanel;

    [SerializeField]
    private GameObject _buyPanel;

    [SerializeField]
    private UIPanel _uiPanel;

    public int Score { get; set; }

    public int Coin { get; set; }

    public int BestScore { get; set; }

    //private int score = 10;

    public void Start()
    {
        //기존에 저장되 값을 불러온다
        _uiPanel.bestClickScore.text = "TOP : " + PlayerPrefs.GetInt("BESTSCORE", 0).ToString();
        _uiPanel.coinText.text = PlayerPrefs.GetInt("COIN", 0).ToString();

        //BestScore 와 Coin 값에 예전 값을 넣어 둔다
        BestScore = PlayerPrefs.GetInt("BESTSCORE", 0);
        Coin = PlayerPrefs.GetInt("COIN", 0);

        TimeStop();
    }

    // 코인점수 증가
    public void CoinUp()
    {
        Coin += 10;

        _uiPanel.coinText.text = Coin.ToString();

        PlayerPrefs.SetInt("COIN", Coin);
    }

    public void ScoreUp()
    {
        Score++;

        // 클릭 카운트가 베스트클릭카운트보다 높을시 갱신
        if (Score > BestScore)
        {
            BestScore = Score;

            _uiPanel.bestClickScore.text = "TOP : " + BestScore.ToString();
        }
        // 클릭 카운트 표시
        _uiPanel.clickScore.text = Score.ToString();

        // 베스트클릭 점수 저장
        //PlayerPrefs.SetInt("SCORE", Score);
        PlayerPrefs.SetInt("BESTSCORE", BestScore);
    }

    public void CharacterSelect()
    {
        _selectPanel.SetActive(true);

        startPanel.SetActive(false);
    }

    public void TimeStop()
    {
        Time.timeScale = 0;
    }
}