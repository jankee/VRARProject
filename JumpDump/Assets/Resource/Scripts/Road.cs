using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum RoadType
{
    WATER,
    WALKWAY,
    RAILROAD,
    ROADWAY01,
    ROADWAY02,
}

public class Road : MonoBehaviour
{
    [SerializeField]
    private RoadType roadType;

    public RoadType RoadType
    {
        get
        {
            return roadType;
        }
    }

    public Vector2 MoveSpeed
    {
        get
        {
            return moveSpeed;
        }
        set
        {
            moveSpeed = value;
        }
    }

    public Vector3 LaneStart
    {
        get
        {
            return laneStart;
        }
    }

    public Vector3 LaneEnd
    {
        get
        {
            return laneEnd;
        }
    }

    public int MoveDirection
    {
        get
        {
            return moveDirection;
        }
    }

    private Vector3 laneStart = new Vector3(-15, 0, 0);
    private Vector3 laneEnd = new Vector3(15, 0, 0);

    [SerializeField]
    private Vector2 movingObjcetNumber = new Vector2(1, 3);

    [SerializeField]
    private Vector2 moveSpeed = new Vector2(0.5f, 3.5f);

    private int moveDirection = 1;

    [SerializeField]
    private bool randomDirection = true;

    protected virtual void Start()
    {
        //랜덤으로 moveSpeed를 설정 한다
        moveSpeed.x = Random.Range(moveSpeed.x, moveSpeed.y);

        float ran = Random.Range(0, 3f);

        if (randomDirection == true && ran > 1.5f)
        {
            moveDirection = -1;

            //moveSpeed = -moveSpeed;
        }

        //newVehicle.transform.Translate(Vector3.forward * moveSpeed.x * Time.deltaTime);
    }

    private void Update()
    {
        //if (vehicles.Length > 0)
        //{
        //    newVehicle.transform.Translate(Vector3.forward * moveSpeed.x * Time.deltaTime);
        //}
    }
}