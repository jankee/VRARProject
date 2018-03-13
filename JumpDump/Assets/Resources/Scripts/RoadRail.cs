using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadRail : Road
{
    [SerializeField]
    private GameObject[] vehicles;

    [SerializeField]
    private Vector2 ranIntVector = new Vector2(0, 10);

    private Animator anim;

    private GameObject newVehicle;

    private float randomTime = 0;

    // Use this for initialization
    protected override void Start()
    {
        base.Start();

        anim = GetComponent<Animator>();

        randomTime = Random.Range(0.1f, 1f);

        StartCoroutine(Process());
    }

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
                    StartCoroutine(CreateTrain(LaneEnd, LaneStart, ranTime));

                    yield break;
                }

                StartCoroutine(CreateTrain(LaneStart, LaneEnd, ranTime));
            }

            yield return new WaitForSeconds(5f);
        }
    }

    private IEnumerator CreateTrain(Vector3 start, Vector3 end, float ran)
    {
        anim.SetTrigger("LIGHTING");

        yield return new WaitForSeconds(2.5f);

        newVehicle = Instantiate(vehicles[0]);

        newVehicle.transform.SetParent(this.transform);
        newVehicle.transform.position = this.transform.position + start;
        newVehicle.transform.LookAt(this.transform.position + end);

        //재 시작되는 값을 랜덤하게 생성
        StartCoroutine(newVehicle.GetComponent<Vehicle>().MoveForward(start, end, MoveSpeed.x, MoveDirection));
    }
}