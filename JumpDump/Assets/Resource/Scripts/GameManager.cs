using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    // 게임 종료 여부 (플래그(On/Off) 변수)
    public static bool IsGameStop = false;

    //게임 일시 정지
    private void Update()
    {
        // 게임이 종료 상태면
        if (IsGameStop)
        {
            // 이동을 정지함
            Time.timeScale = 0; //게임전체 진행속도
        }

    }


}



    /*

    //
    public float _topLimitPosX;
    public float _bottomLimitPosX;
    public float _topLimitPosZ;
    public float _bottomLimitPosZ;

    public float _startDelayTime;
    public float _createDelayTime;

    
    private void Start()
    {
        StartCoroutine("CreateCoinCoroutine");
    }
    
    // 코인 랜덤 생성
    private IEnumerator CreateCoinCoroutine()
    {
        yield return new WaitForSeconds(_startDelayTime);

        while (true)
        {
            float randX = Random.Range(_topLimitPosX, _bottomLimitPosX);
            float randZ = Random.Range(_topLimitPosZ, _bottomLimitPosZ);

            //생성위치
            Vector2 createPos = new Vector2(_createPos.position.x + randX, _createPos.position.z + randZ);
            Instantiate(_coinPrefab, createPos, Quaternion.identity);

            yield return new WaitForSeconds(_createDelayTime);
        }

    }
  */
