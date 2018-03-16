using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadTransport : Road
{
    [SerializeField]
    private GameObject[] Transports;

    [SerializeField]
    private Vector2 repeatChance = new Vector2(1, 10);

    private GameObject newTransport;

    private Animator anim;

    // Use this for initialization
    protected override void Start()
    {
        base.Start();

        //randomTime.x = Random.Range(randomTime.x, randomTime.y);

        anim = GetComponent<Animator>();

        StartCoroutine(ProcessRoutine());

        if (PhotonNetwork.isMasterClient)
        {
            if (MoveDirection == -1)
            {
                StartCoroutine(CreateTransport(LaneEnd, LaneStart));

                return;
            }

            StartCoroutine(CreateTransport(LaneStart, LaneEnd));
        }
    }

    private IEnumerator CreateTransport(Vector3 start, Vector3 end)
    {
        if (anim != null)
        {
            anim.SetTrigger("LIGHTING");

            yield return new WaitForSeconds(2.5f);
        }

        int selNum = Random.Range(0, Transports.Length);

        print("Prefabs/" + Transports[selNum].name);

        newTransport = PhotonNetwork.Instantiate("Prefabs/" + Transports[selNum].name, this.transform.position + start, Quaternion.identity, 0);

        //서버동기화
        photonView.RPC("TransportSet", PhotonTargets.AllViaServer, start, end);
    }

    [PunRPC]
    private void TransportSet(Vector3 start, Vector3 end)
    {
        newTransport.transform.SetParent(this.transform);
        newTransport.transform.LookAt(this.transform.position + end);

        //재 시작되는 값을 랜덤하게 생성
        newTransport.GetComponent<Transport>().MoveForward(start, end, MoveSpeed.x, MoveDirection);
    }

    // Update is called once per frame
    private IEnumerator ProcessRoutine()
    {
        if (PhotonNetwork.isMasterClient)
        {
            while (true)
            {
                yield return null;

                int randomNum = (int)Random.Range(this.repeatChance.x, this.repeatChance.y);

                print("repeatChance : " + repeatChance);

                if ((int)randomNum == 0)
                {
                    if (MoveDirection == -1)
                    {
                        StartCoroutine(CreateTransport(LaneEnd, LaneStart));

                        yield return new WaitForSeconds(1f);

                        yield break;
                    }

                    StartCoroutine(CreateTransport(LaneStart, LaneEnd));
                }

                yield return new WaitForSeconds(2f);
            }
        }
    }
}