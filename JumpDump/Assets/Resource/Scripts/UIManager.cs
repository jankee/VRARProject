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

    [SerializeField]
    private Light mainLight;

    [SerializeField]
    private Light secondLight;

    public GameObject StartPanel
    {
        get
        {
            return startPanel;
        }

        set
        {
            startPanel = value;
        }
    }

    public GameObject SelectPanel
    {
        get
        {
            return _selectPanel;
        }

        set
        {
            _selectPanel = value;
        }
    }

    public GameObject BuyPanel
    {
        get
        {
            return _buyPanel;
        }

        set
        {
            _buyPanel = value;
        }
    }

    //private int score = 10;

    public void Start()
    {
        //기존에 저장되 값을 불러온다
        _uiPanel.bestClickScore.text = "TOP : " + PlayerPrefs.GetInt("BESTSCORE", 0).ToString();
        _uiPanel.coinText.text = PlayerPrefs.GetInt("COIN", 0).ToString();

        //BestScore 와 Coin 값에 예전 값을 넣어 둔다
        BestScore = PlayerPrefs.GetInt("BESTSCORE", 0);
        Coin = PlayerPrefs.GetInt("COIN", 0);

        //StartPanelUI 실행
        StartPanelUI();

        GamePause();
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

    public void CharacterSelectUI()
    {
        _selectPanel.SetActive(true);

        startPanel.SetActive(false);

        _buyPanel.SetActive(false);

        mainLight.enabled = false;

        secondLight.enabled = true;
    }

    public void StartPanelUI()
    {
        startPanel.SetActive(true);

        _selectPanel.SetActive(false);

        _buyPanel.SetActive(false);
    }

    public void GamePause()
    {
        secondLight.enabled = false;

        mainLight.enabled = true;

        Time.timeScale = 0f;
    }

    public void GameUnpause()
    {
        startPanel.SetActive(false);

        _selectPanel.SetActive(false);

        _buyPanel.SetActive(false);

        secondLight.enabled = false;

        mainLight.enabled = true;

        Time.timeScale = 1f;
    }
}