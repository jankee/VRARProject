using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadGenerator : MonoBehaviour
{
    [SerializeField]
    private Road[] roads;

    private string roadType;

    // Use this for initialization
    private void Start()
    {
        CreatRoad();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            this.transform.position += new Vector3(0, 0, -1);
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

    public void CreatRoad()
    {
        for (int i = -6; i < 20; i++)
        {
            int rand = Random.Range(0, 4);
            switch (rand)
            {
                case 0:
                    roadType = RoadType.RAILROAD.ToString();
                    break;

                case 1:
                    roadType = RoadType.ROADWAY.ToString();
                    break;

                case 2:
                    roadType = RoadType.WALKWAY.ToString();
                    break;

                case 3:
                    roadType = RoadType.WATER.ToString();
                    break;
            }
            print(roadType);
            foreach (Road road in roads)
            {
                if (road.RoadType.ToString() == roadType)
                {
                    Road tmp = Instantiate(road, transform.position + new Vector3(0, 0, i),
                        Quaternion.identity, this.transform);
                }
            }
        }
    }

    public void AddRoad()
    {
        if (transform.position.z < 0)
        {
        }
    }
}