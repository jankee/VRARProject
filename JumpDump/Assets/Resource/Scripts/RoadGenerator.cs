using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadGenerator : Singleton<RoadGenerator>
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

    private int roadCount = 0;

    // Use this for initialization
    private void Start()
    {
        moveRoutine = null;

        InitializationRoad();
    }

    // Update is called once per frame
    private void Update()
    {
        ///로드가 움이지이는 걸 막았음
        //if (Input.GetKeyDown(KeyCode.W))
        //{
        //    this.transform.position += new Vector3(0, 0, -1);

        //    AddRoad(new Vector3(0, 0, -1));

        //    //RemoveRoad();
        //}
        //if (Input.GetKeyDown(KeyCode.S))
        //{
        //    this.transform.position += new Vector3(0, 0, 1);
        //}
        //if (Input.GetKeyDown(KeyCode.A))
        //{
        //    this.transform.position += new Vector3(1, 0, 0);
        //}
        //if (Input.GetKeyDown(KeyCode.D))
        //{
        //    this.transform.position += new Vector3(-1, 0, 0);
        //}
    }

    public void RoadDirection(string dir)
    {
        ///로드가 움직임을 막았음
        //switch (dir)
        //{
        //    case "right":
        //        //this.transform.position += new Vector3(-1, 0, 0);

        //        if (moveRoutine != null)
        //        {
        //            StopCoroutine(moveRoutine);
        //            moveRoutine = null;
        //        }

        //        moveRoutine = StartCoroutine(MoveRoutine(new Vector3(-1, 0, 0)));

        //        //AddRoad(new Vector3(0, 0, -1));
        //        //RemoveRoad();
        //        break;

        //    case "down":
        //        //this.transform.position += new Vector3(0, 0, 1);
        //        if (moveRoutine != null)
        //        {
        //            StopCoroutine(moveRoutine);
        //            moveRoutine = null;
        //        }

        //        moveRoutine = StartCoroutine(MoveRoutine(new Vector3(0, 0, 1)));

        //        AddRoad(new Vector3(0, 0, 1));
        //        //RemoveRoad(new Vector3(0, 0, 1));
        //        break;

        //    case "left":
        //        //this.transform.position += new Vector3(1, 0, 0);
        //        if (moveRoutine != null)
        //        {
        //            StopCoroutine(moveRoutine);
        //            moveRoutine = null;
        //        }

        //        moveRoutine = StartCoroutine(MoveRoutine(new Vector3(1, 0, 0)));

        //        //AddRoad(new Vector3(0, 0, -1));
        //        //RemoveRoad();
        //        break;

        //    case "up":

        //        if (moveRoutine != null)
        //        {
        //            StopCoroutine(moveRoutine);
        //            moveRoutine = null;
        //        }

        //        moveRoutine = StartCoroutine(MoveRoutine(new Vector3(0, 0, -1)));

        //        //Camerafollow.Instance.MoveCamera(new Vector3(0, 0, -1));

        //        AddRoad(new Vector3(0, 0, -1));

        //        //RemoveRoad(new Vector3(0, 0, -1));
        //        break;
        //}
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
        if (columCount == 0 || columCount == 1)
        {
            rand = 0;
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

        CreateRoad(columCount, roadType);
    }

    private void CreateRoad(int i, RoadType roadType)
    {
        foreach (Road road in roads)
        {
            if (road.RoadType == roadType)
            {
                Road tmp = Instantiate(road, transform.position + new Vector3(0, 0, i),
                    Quaternion.identity, this.transform);

                tmp.GetComponent<Road>();

                roadsList.Add(tmp);
            }
        }
    }

    public void AddRoad(Vector3 count)
    {
        //여기서
        if (count.z == -1)
        {
            //컬럼에 하나를 더 해준다
            columCount++;

            rowCount++;

            RandomRoad(columCount);
        }
        else if (count.z == 1)
        {
            columCount--;

            rowCount--;

            RandomRoad(rowCount);
        }
    }

    public void FindPlayer()
    {
        List<Player> tmp = new List<Player>();

        Player[] tmpPlayer = GameObject.FindObjectsOfType<Player>();

        for (int i = 0; i < tmpPlayer.Length; i++)
        {
            if (roadCount < (int)tmpPlayer[i].transform.position.z)
            {
                roadCount = (int)tmpPlayer[i].transform.position.z;

                columCount++;

                RandomRoad(columCount);

                print(" Count : " + roadCount);
            }
        }
    }

    public void RemoveRoad(Vector3 vector)
    {
        //road의 z 위치 값이 19를 넘거나 -6 이하 로 있으면 지울려고 합니다.
        if (roadsList.Count > 26)
        {
            //그래서 foreach문이 실행이 안됩니다.
            foreach (Road road in roadsList)
            {
                print(road.name + " : " + road.transform.position + ", " + road.transform.localPosition);
                if (road.transform.position.z > 19 || road.transform.position.z < -6)
                {
                    roadsList.Remove(road);
                    Destroy(road.gameObject);
                }
            }
        }
    }
}