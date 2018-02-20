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

    [SerializeField]
    private GameObject[] vehicles;

    private Vector3 laneStart = new Vector3(-15, 0, 0);
    private Vector3 laneEnd = new Vector3(15, 0, 0);

    private Vector2 moveSpeed = new Vector2(0.5f, 1.5f);

    private int moveDirection = 1;

    private bool randomDirection = true;

    private GameObject newVehicle;

    private void Start()
    {
        int ran = Random.Range(0, 2);

        if (randomDirection == true && Random.value > 0.5f)
        {
            moveDirection = -1;
        }

        moveSpeed.x = Random.Range(moveSpeed.x, moveSpeed.y);

        float laneLength = Vector3.Distance(laneStart, laneEnd);

        newVehicle = Instantiate(vehicles[0]);

        newVehicle.transform.SetParent(this.transform);
        newVehicle.transform.position = this.transform.position + laneStart;
        newVehicle.transform.LookAt(this.transform.position + laneEnd);

        //newVehicle.transform.Translate(Vector3.forward * moveSpeed.x * Time.deltaTime);
    }

    private void Update()
    {
        newVehicle.transform.Translate(Vector3.forward * moveSpeed.x * Time.deltaTime);
    }

    private IEnumerator CreateVehicleRoutine(float wait, int pos)
    {
        yield return new WaitForSeconds(wait);

        Instantiate(vehicles[0], new Vector3(pos, 0, 0), Quaternion.identity, this.transform);
    }
}