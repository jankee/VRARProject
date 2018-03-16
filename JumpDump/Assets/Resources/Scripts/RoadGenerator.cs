using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadGenerator : Photon.MonoBehaviour
{
    [SerializeField]
    private Road[] roads;

    [SerializeField]
    private int roadStart = -10;

    [SerializeField]
    private int roadEnd = 30;

    private List<Road> roadsList = new List<Road>();

    private RoadType roadType;

    //private int columCount = 0;

    private int rowCount = -6;

    private Coroutine moveRoutine;

    private Vector3 startPos;

    private Vector3 endPos;

    private int firstPos = 0;

    private int lastPos = 0;

    private int roadStartCount = 0;

    private int roadEndCount = 0;

    private string[] roadName;

    private Player[] tmpPlayer;

    private List<Road> tmpRoadList = new List<Road>();

    [SerializeField]
    private GameManager gameManager;

    // Use this for initialization
    private void Start()
    {
        roadName = new string[5] { "Road_001", "Road_002", "Road_003", "Road_004", "Road_005" };

        moveRoutine = null;

        roadEndCount = roadEnd - 1;

        roadStartCount = roadStart;

        //gameManager = GameObject.FindObjectOfType<GameManager>();

        //InitializationRoad();
    }

    private IEnumerator MoveRoutine(Vector3 endPos)
    {
        float duration = 0f;

        startPos = this.transform.position;

        Vector3 end = startPos + endPos;

        while (duration < 0.5f)
        {
            duration += Time.deltaTime;

            float perc = duration * 2f;

            transform.position = Vector3.Lerp(startPos, end, perc);

            yield return null;
        }

        //위치 값의 소수점을 버림
        transform.position = new Vector3
            (
                Mathf.Round(transform.position.x),
                0,
                Mathf.Round(transform.position.z)
            );
    }

    //시작되면 화면 26개의 road가 생성됩니다. 로드가 생성되면 roadsList에 등록되게 만들었습니다.
    public void InitializationRoad()
    {
        //로드 제네레이터 위치 값을 0
        this.transform.position = Vector3.zero;

        //roadEndCount = roadStart;

        foreach (Road road in roadsList)
        {
            Destroy(road.gameObject);
        }

        roadsList.Clear();

        //지정된 갯수만큼 랜덤 로드를 생성
        for (int i = roadStart; i < roadEnd; i++)
        {
            RandomRoad(i);
        }
    }

    private void RandomRoad(int roadNum)
    {
        int randomNum;

        //플레이어가 있는 0, 1 위치에는 워크로드 생성
        if (roadNum >= 0 && roadNum <= 4)
        {
            randomNum = 2;
        }
        else
        {
            //랜덤 하게 번호 저장
            randomNum = Random.Range(0, roads.Length);
        }

        switch (randomNum)
        {
            case 0:
                roadType = RoadType.RAILROAD;
                break;

            case 1:
                roadType = RoadType.ROADWAY01;
                break;

            case 2:
                roadType = RoadType.WALKWAY;
                break;

            case 3:
                roadType = RoadType.WATER;
                break;

            case 4:
                roadType = RoadType.ROADWAY02;
                break;
        }

        //PhotonNetwork.RPC()
        //photonView.RPC("CreateRoad", PhotonTargets.AllViaServer, roadNum, roadType);

        CreateRoad(roadNum, roadType);
    }

    //[PunRPC]
    private void CreateRoad(int roadNum, RoadType roadType)
    {
        for (int i = 0; i < roads.Length; i++)
        {
            if (roads[i].RoadType == roadType)
            {
                for (int j = 0; j < roadName.Length; j++)
                {
                    if (roads[i].name == roadName[j])
                    {
                        GameObject tmpRoad = PhotonNetwork.Instantiate("Prefabs/" + roadName[j],
                                             transform.position + new Vector3(0, 0, roadNum),
                                             Quaternion.identity, 0);

                        tmpRoad.GetComponent<Road>().InitRoad();

                        roadsList.Add(tmpRoad.GetComponent<Road>());
                    }
                }

                //GameObject tmpRoad = PhotonNetwork.Instantiate(roads[i].gameObject,
                //    transform.position + new Vector3(0, 0, roadNum),
                //    Quaternion.identity, this.transform);
            }
        }

        print(roadsList.Count);
    }

    public void FindPlayer()
    {
        ///*Player[] */
        //tmpPlayer = GameObject.FindObjectsOfType<Player>();

        //맵에 로드 갯수를 확인
        tmpRoadList.Clear();

        tmpRoadList.AddRange(GameObject.FindObjectsOfType<Road>());

        Road tmpRoad = new Road();

        int startNum = 0;

        int lastNum = 0;

        for (int i = 0; i < tmpRoadList.Count; i++)
        {
            for (int j = 0; j < tmpRoadList.Count; j++)
            {
                if (tmpRoadList[i].transform.position.z > tmpRoadList[j].transform.position.z)
                {
                    tmpRoad = tmpRoadList[i];

                    tmpRoadList[i] = tmpRoadList[j];

                    tmpRoadList[j] = tmpRoad;
                }
            }
        }

        startNum = (int)tmpRoadList[0].transform.position.z;

        lastNum = (int)tmpRoadList[tmpRoadList.Count - 1].transform.position.z;

        print(" Start Num : " + startNum + " Last Num : " + lastNum);

        //캐릭터 배열의 순서를 정함
        tmpPlayer = gameManager.FindRankPlayer();

        int playerFirstNum = (int)tmpPlayer[0].transform.position.z + roadEndCount;

        int playerLastNum = (int)tmpPlayer[tmpPlayer.Length - 1].transform.position.z + roadStartCount;

        print("playerFirstNum : " + playerFirstNum + ", playerLastNum : " + playerLastNum);

        if (playerFirstNum > startNum)
        {
            RandomRoad(playerFirstNum);
        }

        if (playerLastNum > lastNum)
        {
            RemoveRoad(playerLastNum);
        }
    }

    //[PunRPC]
    public void RemoveRoad(int endNum)
    {
        //List<Road> tmpRoadList = new List<Road>(GameObject.FindObjectsOfType<Road>());

        print("Remove" + endNum);

        //PhotonNetwork.Destroy(tmpRoadList[i].gameObject);

        //Road[] tmpRemove;

        for (int i = 0; i < tmpRoadList.Count; i++)
        {
            if (tmpRoadList[i].transform.position.z < endNum)
            {
                PhotonNetwork.Destroy(tmpRoadList[i].gameObject);
            }
        }

        //tmpRoadList.Remove(tmpRemove);
        //그래서 foreach문이 실행이 안됩니다.
        //foreach (Road road in roadsList)
        //{
        //    //print(road.name + " : " + road.transform.position + ", " + road.transform.localPosition);

        //}

        //람다식 방법
        //var findRoads = roadsList.FindAll(
        //    (Road r) =>
        //    {
        //        if (r.transform.position.z < value)
        //            return true;
        //        else
        //            return false;
        //    });

        //Destroy(findRoads.);
    }
}