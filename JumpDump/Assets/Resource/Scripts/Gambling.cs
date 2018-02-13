using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Gambling : MonoBehaviour {

    public Text _coinText;
    public Text _resultCoinText;
    GameObject rr;
    // 캐릭터 목록 프리팹
    public GameObject[] _characterPrefab;
    public Transform _genPos;

    private void Start()
    {
        int value = int.Parse(_coinText.text);

        rr = null;
    }

    // 뽑기 버튼 실행
    public void GambleButtonClick()
    {
        int value = int.Parse(_coinText.text);
        // 100원 이하시 뽑기 금지
        if (value < 100)
        {
            _resultCoinText.text = "Fail";
            return;
        }
        // 100원 이상시 뽑기 실행
        else
        {            
            value -= 100;
            _coinText.text = value.ToString();
            //Destroy(rr.gameObject);

            if (rr != null)
            {
                Destroy(rr.gameObject);
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

        rr = Instantiate(prefab, _genPos.position, Quaternion.identity);

        
    }
   
    // 인터페이스로 돌아감
    /*public void ReturnBotton()
    {
        SceneManager.LoadScene("");
    }*/
}
