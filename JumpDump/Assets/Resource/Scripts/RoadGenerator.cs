using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadGenerator : MonoBehaviour
{
    [SerializeField]
    private Road[] roads;

    private List<Road> roadsList = new List<Road>();

    private RoadType roadType;

    private int columCount = 0;

    private int rowCount = -6;

    private Coroutine moveRoutine;

    private Vector3 startPos;

    private Vector3 endPos;

    // Use this for initialization
    private void Start()
    {
        moveRoutine = null;

        InitializationRoad();
    }

    // Update is called once per frame
    private void Update()
    {
        print("Time : " + Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.W))
        {
            this.transform.position += new Vector3(0, 0, -1);

            AddRoad(new Vector3(0, 0, -1));

            //RemoveRoad();
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            this.transform.position += new Vector3(0, 0, 1);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            this.transform.position += new Vector3(1, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            this.transform.position += new Vector3(-1, 0, 0);
        }
    }

    public void RoadDirection(string dir)
    {
        switch (dir)
        {
            case "right":
                //this.transform.position += new Vector3(-1, 0, 0);

                if (moveRoutine != null)
                {
                    StopCoroutine(moveRoutine);
                    moveRoutine = null;
                }

                moveRoutine = StartCoroutine(MoveRoutine(new Vector3(-1, 0, 0)));

                //AddRoad(new Vector3(0, 0, -1));
                //RemoveRoad();
                break;

            case "down":
                //this.transform.position += new Vector3(0, 0, 1);
                if (moveRoutine != null)
                {
                    StopCoroutine(moveRoutine);
                    moveRoutine = null;
                }

                moveRoutine = StartCoroutine(MoveRoutine(new Vector3(0, 0, 1)));

                AddRoad(new Vector3(0, 0, 1));
                RemoveRoad(new Vector3(0, 0, 1));
                break;

            case "left":
                //this.transform.position += new Vector3(1, 0, 0);
                if (moveRoutine != null)
                {
                    StopCoroutine(moveRoutine);
                    moveRoutine = null;
                }

                moveRoutine = StartCoroutine(MoveRoutine(new Vector3(1, 0, 0)));

                //AddRoad(new Vector3(0, 0, -1));
                //RemoveRoad();
                break;

            case "up":
                //this.transform.position += new Vector3(0, 0, -1);
                print("startPos : " + startPos);

                if (moveRoutine != null)
                {
                    StopCoroutine(moveRoutine);
                    moveRoutine = null;
                }

                moveRoutine = StartCoroutine(MoveRoutine(new Vector3(0, 0, -1)));

                AddRoad(new Vector3(0, 0, -1));

                RemoveRoad(new Vector3(0, 0, -1));
                break;
        }
    }

    private IEnumerator MoveRoutine(Vector3 endPos)
    {
        float duration = 0f;

        startPos = this.transform.position;

        Vector3 end = startPos + endPos;

        while (duration < 0.5f)
        {
            duration += 0.02f;

            float perc = duration * 2f;

            print("start : " + startPos + ", end : " + end + ", duration : " + Time.deltaTime);
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
        print("Roads List : " + roadsList.Count);

        for (int i = -6; i < 20; i++)
        {
            columCount = i;

            RandomRoad(columCount);
        }
    }

    private void RandomRoad(int columCount)
    {
        int rand = Random.Range(0, 5);
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

    public void RemoveRoad(Vector3 vector)
    {
        //여기서 roadsList의 갯수가 26개 일것 같은데 39개로 나옵니다
        print("remove : " + roadsList.Count);

        //road의 z 위치 값이 19를 넘거나 -6 이하 로 있으면 지울려고 합니다.
        if (roadsList.Count > 26)
        {
            //    //여기서 roadsList 카운트가 39개인데 road는 null이 뜹니다. 왜그런지 이유를 모르겠습니다
            //    //그래서 foreach문이 실행이 안됩니다.
            foreach (Road road in roadsList)
            {
                print(road.transform.position);

                if (road.transform.localRotation.z > 19 || road.transform.position.z < -6)
                {
                    roadsList.Remove(road);
                    Destroy(road.gameObject);
                }
            }
        }
    }
}