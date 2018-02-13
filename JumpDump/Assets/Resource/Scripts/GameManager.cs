using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    
    public Transform _createPos; //생성위치
    public GameObject _objectPrefab;

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
            Instantiate(_objectPrefab, createPos, Quaternion.identity);

            yield return new WaitForSeconds(_createDelayTime);
        }

    }
  
}
