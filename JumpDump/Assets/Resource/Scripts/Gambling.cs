using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Gambling : MonoBehaviour {

    public Text _coinText;
    public Text _resultCoinText;
    GameObject _cha1;
    GameObject[] _chaSave;
    // 캐릭터 목록 프리팹
    public GameObject[] _characterPrefab;
    public Transform _genPos;

    UIManager _uimanager;

    private void Start()
    {
        _uimanager = GameObject.FindObjectOfType<UIManager>();
        int coin = int.Parse(_coinText.text);

        _cha1 = null;
    }

    // 뽑기 버튼 실행
    public void GambleButtonClick()
    {
        int coin = int.Parse(_coinText.text);
        // 500원 이하시 뽑기 금지
        if (coin < 500)
        {
            _resultCoinText.text = "Fail";
            return;
        }
        // 500원 이상시 뽑기 실행
        else
        {
            coin -= 500;
            _coinText.text = coin.ToString();
            //Destroy(rr.gameObject);

            if (_cha1 != null)
            {
                Destroy(_cha1.gameObject);
            }
            CharacterRandomBuy();
                        
        }
    }

    // 구매가능 캐릭터 랜덤 뽑기 설정
    public void CharacterRandomBuy()
    {
       
        int prefabNum = Random.Range(0, 10);
        GameObject prefab;
        if (prefabNum > 7)
        {
            prefab = _characterPrefab[2];
        }
        else if (prefabNum > 4)
        {
            prefab = _characterPrefab[1];
        }
        else
        {
            prefab = _characterPrefab[0];
        }

        _cha1 = Instantiate(prefab, _genPos.position, Quaternion.identity);

        
        
    }
   
    // 캐럭터 선택창으로 돌아감
    public void ReturnBotton()
    {
        _uimanager._select.SetActive(true);
        _uimanager._score.SetActive(true);
        _uimanager._buy.SetActive(false);
    }
}
