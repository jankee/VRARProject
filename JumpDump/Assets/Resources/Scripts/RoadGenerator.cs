using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadGenerator : Photon.MonoBehaviour
{
    [SerializeField]
    private Road[] roads;

    [SerializeField]
    private int roadStart = -8;

    [SerializeField]
    private int roadEnd = 26;

    private List<Road> roadsList = new List<Road>();

    private RoadType roadType;

    private int columCount = 0;

    private int rowCount = -6;

    private Coroutine moveRoutine;

    private Vector3 startPos;

    private Vector3 endPos;

    private int firstPos = 0;

    private int lastPos = 0;

    private int roadEndCount = 0;

    private string[] roadName;

    // Use this for initialization
    private void Start()
    {
        roadName = new string[5] { "Road_001", "Road_002", "Road_003", "Road_004", "Road_005" };

        moveRoutine = null;

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
        this.transform.position = Vector3.zero;

        roadEndCount = roadStart;

        foreach (Road road in roadsList)
        {
            Destroy(road.gameObject);
        }

        roadsList.Clear();

        for (int i = roadStart; i < roadEnd; i++)
        {
            columCount = i;

            RandomRoad(columCount);
        }
    }

    private void RandomRoad(int columCount)
    {
        int rand;

        //플레이어가 있는 0, 1 위치에는 일반 도로 생성
        if (columCount >= 0 && columCount <= 4)
        {
            rand = 2;
        }
        else
        {
            rand = Random.Range(0, 5);
        }

        switch (rand)
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
        photonView.RPC("CreateRoad", PhotonTargets.AllViaServer, columCount, roadType);
    }

    [PunRPC]
    private void CreateRoad(int num, RoadType roadType)
    {
        for (int i = 0; i < roads.Length; i++)
        {
            if (roads[i].RoadType == roadType)
            {
                for (int j = 0; j < roadName.Length; j++)
                {
                    if (roads[i].name == roadName[j])
                    {
                        print("roads : " + roads[i].name + ", roadName : " + roadName[j]);
                        GameObject tmp = PhotonNetwork.Instantiate("Prefabs/" + roadName[j], transform.position + new Vector3(0, 0, num),
                            Quaternion.identity, 0);

                        tmp.transform.SetParent(this.transform);

                        roadsList.Add(tmp.GetComponent<Road>());

                        break;
                    }
                }
            }
        }
    }

    //public void AddRoad(Vector3 count)
    //{
    //    //여기서
    //    if (count.z == -1)
    //    {
    //        //컬럼에 하나를 더 해준다
    //        columCount++;

    //        rowCount++;

    //        RandomRoad(columCount);
    //    }
    //    else if (count.z == 1)
    //    {
    //        columCount--;

    //        rowCount--;

    //        RandomRoad(rowCount);
    //    }
    //}

    //public void CallFindPlayer()
    //{
    //    photonView.RPC("FindPlayer", PhotonTargets.AllViaServer);
    //}

    public void FindPlayer()
    {
        List<Player> tmp = new List<Player>();

        Player[] tmpPlayer = GameObject.FindObjectsOfType<Player>();

        print("tmpPlayer : " + tmpPlayer.Length);

        //최초 위치를 기록
        firstPos = (int)tmpPlayer[0].transform.position.z;

        lastPos = (int)tmpPlayer[0].transform.position.z;

        //로드가 생성되는 기준을 알기 위해 제일 앞에 있는 플레어의 z값을 확인
        for (int i = 0; i < tmpPlayer.Length; i++)
        {
            if (firstPos < (int)tmpPlayer[i].transform.position.z)
            {
                firstPos = (int)tmpPlayer[i].transform.position.z;

                columCount++;

                RandomRoad(columCount);
            }
        }

        //플레이어 중 가장 뒤에 있는 위치값을 찾는다
        for (int i = 0; i < tmpPlayer.Length; i++)
        {
            if (lastPos > (int)tmpPlayer[i].transform.position.z)
            {
                lastPos = (int)tmpPlayer[i].transform.position.z;
            }

            lastPos += roadEndCount;

            //photonView.RPC("RemoveRoad", PhotonTargets.AllViaServer, lastPos);
            RemoveRoad(lastPos);
        }

        print(" firstPos : " + firstPos + ", lastPos :" + lastPos);
    }

    //[PunRPC]
    public void RemoveRoad(int value)
    {
        //그래서 foreach문이 실행이 안됩니다.
        foreach (Road road in roadsList)
        {
            //print(road.name + " : " + road.transform.position + ", " + road.transform.localPosition);
            if (road.transform.position.z < value)
            {
                roadsList.Remove(road);
                PhotonNetwork.Destroy(road.gameObject);
                break;
            }
        }

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