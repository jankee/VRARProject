using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    // 게임 종료 여부 (플래그(On/Off) 변수)
    public bool IsGameOver { get; set; }

    public int Score { get; set; }

    public int Coin { get; set; }

    public int BestScore { get; set; }

    public bool IsPaused { get; set; }

    [SerializeField]
    private Camera mainCamera;

    public Camera MainCamera
    {
        get
        {
            return mainCamera;
        }
        set
        {
            mainCamera = value;
        }
    }

    [SerializeField]
    private Camera characterCamera;

    public Camera CharacterCamera
    {
        get
        {
            return characterCamera;
        }
        set
        {
            characterCamera = value;
        }
    }

    [SerializeField]
    private GameObject[] characterArray;

    private GameObject player;

    private int scoreKeep = 0;

    public GameObject Player
    {
        get
        {
            return player;
        }
    }

    [SerializeField]
    private GameObject introPanel;

    [SerializeField]
    private GameObject selectPanel;

    [SerializeField]
    private GameObject buyPanel;

    [SerializeField]
    private GameObject pausePanel;

    [SerializeField]
    private UIPanel uiPanel;

    [SerializeField]
    private Light mainLight;

    [SerializeField]
    private Light secondLight;

    public void Awake()
    {
        IsGameOver = false;
        IsPaused = false;

        //기존에 저장되 값을 불러온다
        uiPanel.bestClickScore.text = "TOP : " + PlayerPrefs.GetInt("BESTSCORE", 0).ToString();
        uiPanel.coinText.text = PlayerPrefs.GetInt("COIN", 0).ToString();

        //BestScore 와 Coin 값에 예전 값을 넣어 둔다
        BestScore = PlayerPrefs.GetInt("BESTSCORE", 0);
        Coin = PlayerPrefs.GetInt("COIN", 0);
        Score = 0;

        UIIntroPanel();

        SetPlayer();

        //시작을 한후 일시 정지
        //GamePause();
        Time.timeScale = 0;
        IsPaused = false;
    }

    public void SetPlayer()
    {
        if (player != null)
        {
            Destroy(player.gameObject);
        }

        int num = PlayerPrefs.GetInt("SELECTPLAYER", 0);

        player = Instantiate(characterArray[num]);

        player.name = "Player";

        Player.transform.position = Vector3.zero;
    }

    public void UIIntroPanel()
    {
        introPanel.SetActive(true);

        selectPanel.SetActive(false);

        buyPanel.SetActive(false);

        pausePanel.SetActive(false);

        //카메라 조정
        mainCamera.enabled = true;
        characterCamera.enabled = false;

        //라이트 조정
        mainLight.enabled = true;
        secondLight.enabled = false;
    }

    public void UICharacterSelect()
    {
        introPanel.SetActive(false);

        selectPanel.SetActive(true);

        buyPanel.SetActive(false);

        pausePanel.SetActive(false);

        //카메라 조정
        mainCamera.enabled = false;
        characterCamera.enabled = true;

        //라이트 조정
        mainLight.enabled = false;
        secondLight.enabled = true;

        RoadGenerator.Instance.InitializationRoad();
    }

    public void StartPlay()
    {
        //패널 조정
        introPanel.SetActive(false);

        selectPanel.SetActive(false);

        buyPanel.SetActive(false);

        pausePanel.SetActive(false);

        //카메라 조정
        mainCamera.enabled = true;
        characterCamera.enabled = false;

        //라이트 조정
        mainLight.enabled = true;
        secondLight.enabled = false;

        SetPlayer();

        GameUnpause();
    }

    // 코인점수 증가
    public void CoinUp(int coinValue)
    {
        Coin += coinValue;

        player.GetComponent<PlayerHealth>().TakeHP(10f);

        if (uiPanel.coinText)
        {
            uiPanel.coinText.text = Coin.ToString();
        }

        PlayerPrefs.SetInt("COIN", Coin);
    }

    public void ScoreUp()
    {
        //자신의 최대 치를 자신의 위치를 비교하여 스코어를 올림
        if (scoreKeep < (int)player.transform.position.z)
        {
            scoreKeep = (int)player.transform.position.z;

            Score++;
        }

        // 클릭 카운트가 베스트클릭카운트보다 높을시 갱신
        if (Score > BestScore)
        {
            BestScore = Score;

            uiPanel.bestClickScore.text = "TOP : " + BestScore.ToString();
        }
        // 클릭 카운트 표시
        uiPanel.clickScore.text = Score.ToString();

        // 베스트클릭 점수 저장
        PlayerPrefs.SetInt("BESTSCORE", BestScore);
    }

    public void GamePause()
    {
        //일시중지는 참
        IsPaused = true;

        pausePanel.SetActive(true);

        Time.timeScale = 0f;
    }

    public void GameUnpause()
    {
        //일시중지는 거짓
        IsPaused = false;

        pausePanel.SetActive(false);

        Time.timeScale = 1f;
    }

    private void Restart()
    {
        //Application.loadedLevel(Application.loadedLevelName);
    }

    private void MainMenu()
    {
        //Application.loadedLevel();
    }

    private IEnumerator GameOver(float delay)
    {
        yield return new WaitForSeconds(delay);

        IsGameOver = true;

        if (true)
        {
        }

        int totalCoins = PlayerPrefs.GetInt("COIN", 0);
    }
}