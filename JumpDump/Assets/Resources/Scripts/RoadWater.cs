using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadWater : Road
{
    [SerializeField]
    private GameObject[] vehicles;

    [SerializeField]
    private Vector2 ranIntVector = new Vector2(0, 10);

    private GameObject newVehicle;

    private float randomTime = 0;

    // Use this for initialization
    protected override void Start()
    {
        base.Start();

        randomTime = Random.Range(0.1f, 1f);

        StartCoroutine(Process());

        if (RoadType == RoadType.WATER)
        {
            if (MoveDirection == -1)
            {
                CreateRaft(LaneEnd, LaneStart, randomTime);

                return;
            }
            CreateRaft(LaneStart, LaneEnd, randomTime);
        }
    }

    // Update is called once per frame
    private IEnumerator Process()
    {
        while (true)
        {
            int ranInt = (int)Random.Range(ranIntVector.x, ranIntVector.y);

            if (ranInt == 0)
            {
                float ranTime = Random.Range(randomTime + 0.5f, randomTime + 2f);

                if (MoveDirection == -1)
                {
                    CreateRaft(LaneEnd, LaneStart, ranTime);

                    yield break;
                }

                CreateRaft(LaneStart, LaneEnd, ranTime);
            }

            yield return new WaitForSeconds(2f);
        }
    }

    private void CreateRaft(Vector3 start, Vector3 end, float ran)
    {
        newVehicle = Instantiate(vehicles[0]);

        newVehicle.transform.SetParent(this.transform);
        newVehicle.transform.position = this.transform.position + start;
        newVehicle.transform.LookAt(this.transform.position + end);

        //재 시작되는 값을 랜덤하게 생성
        StartCoroutine(newVehicle.GetComponent<Vehicle>().MoveForward(start, end, MoveSpeed.x, MoveDirection));
    }

    //private IEnumerator CreateVehicleRoutine(float wait, Vector3 start, Vector3 end)
    //{
    //    yield return new WaitForSeconds(wait);

    //    if (MoveDirection == -1)
    //    {
    //        while (newVehicle.transform.position.x > end.x)
    //        {
    //            newVehicle.transform.Translate(Vector3.forward * MoveSpeed.x * Time.deltaTime);

    //            yield return null;
    //        }
    //    }
    //    else
    //    {
    //        while (newVehicle.transform.position.x < end.x)
    //        {
    //            newVehicle.transform.Translate(Vector3.forward * MoveSpeed.x * Time.deltaTime);

    //            yield return null;
    //        }
    //    }

    //    Destroy(newVehicle.gameObject);

    //    CreateRaft(start, end, randomTime);
    //    //Instantiate(vehicles[0], new Vector3(pos, 0, 0), Quaternion.identity, this.transform);
    //}
}