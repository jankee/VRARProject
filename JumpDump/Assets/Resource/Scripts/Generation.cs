using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generation : MonoBehaviour {

    public GameObject Water; //로드타입1
    public GameObject Road; //로드타입2
    public GameObject Grass; //로드타입3

    int firstRand; //첫번째 로드 정수 
    int secondRand; // 두번쨰 로드 정수
    int disPlayer = 4;

    Vector3 intPos = new Vector3(0, 0, 0);

    //플레이어가 앞으로 전진 할 때 랜덤으로 로드 불러오기
	void Update () {

        // up 키를 눌렀다 떼면
	    if(Input.GetButtonDown("up"))
        {
            // 1~3 로드를 랜덤 생성,배치
            firstRand = Random.Range(1,4);
            if (firstRand == 1)
            {
                secondRand = Random.Range(1, 2);
                for(int i= 0;i < secondRand; i++)
                {
                    intPos = new Vector3(0,0,disPlayer);
                    disPlayer += 1;
                    GameObject GrassIns = Instantiate(Grass) as GameObject;
                    GrassIns.transform.position = intPos;
                }
            }
            // 1~3 로드를 랜덤 생성,배치
            if (firstRand == 2)
            {
                secondRand = Random.Range(1, 2);
                for (int i = 0; i < secondRand; i++)
                {
                    intPos = new Vector3(0, -0.1f, disPlayer);
                    disPlayer += 1;
                    GameObject RoadIns = Instantiate(Road) as GameObject;
                    RoadIns.transform.position = intPos;
                }
            }
            // 1~3 로드를 랜덤 생성,배치
            if (firstRand == 3)
            {
                secondRand = Random.Range(1, 2);
                for (int i = 0; i < secondRand; i++)
                {
                    intPos = new Vector3(0, -0.2f, disPlayer);
                    disPlayer += 1;
                    GameObject WaterIns = Instantiate(Water) as GameObject;
                    WaterIns.transform.position = intPos;
                }
            }
        }
	}
}
