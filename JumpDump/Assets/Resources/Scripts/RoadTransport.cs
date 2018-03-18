﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadTransport : Road
{
    [SerializeField]
    private GameObject[] transports;

    [SerializeField]
    private Vector2 repeatChance = new Vector2(1, 10);

    private GameObject newTransport;

    private Animator anim;

    // Use this for initialization
    protected override void Start()
    {
        base.Start();

        //randomTime.x = Random.Range(randomTime.x, randomTime.y);

        if (PhotonNetwork.isMasterClient)
        {
            anim = GetComponent<Animator>();

            StartCoroutine(ProcessRoutine());

            if (MoveDirection == -1)
            {
                print("1");
                StartCoroutine(CreateTransport(LaneEnd, LaneStart));
            }
            else
            {
                print("2");
                StartCoroutine(CreateTransport(LaneStart, LaneEnd));
            }
        }
    }

    public void InitRoad()
    {
        photonView.RPC("InitRoadRPC", PhotonTargets.AllViaServer);
    }

    [PunRPC]
    private void InitRoadRPC()
    {
        Transform parent = GameObject.FindObjectOfType<RoadGenerator>().transform;

        this.transform.SetParent(parent);
    }

    private IEnumerator CreateTransport(Vector3 start, Vector3 end)
    {
        if (transports.Length > 0 && PhotonNetwork.isMasterClient)
        {
            //애니메이터가 있다면
            if (anim != null)
            {
                anim.SetTrigger("LIGHTING");

                yield return new WaitForSeconds(2.5f);
            }

            int selNum = Random.Range(0, transports.Length);

            print("Transport : " + transports.Length);

            print("Prefabs/" + transports[selNum].name);

            newTransport = PhotonNetwork.Instantiate("Prefabs/" + transports[selNum].name, this.transform.position + start, Quaternion.identity, 0);

            //서버동기화
            photonView.RPC("TransportSet", PhotonTargets.AllViaServer, start, end);
        }
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
                int randomNum = (int)Random.Range(this.repeatChance.x, this.repeatChance.y);

                print("repeatChance : " + randomNum);

                if ((int)randomNum == 0)
                {
                    if (MoveDirection == -1)
                    {
                        StartCoroutine(CreateTransport(LaneEnd, LaneStart));
                    }
                    else
                    {
                        StartCoroutine(CreateTransport(LaneStart, LaneEnd));
                    }
                }
                yield return new WaitForSeconds(2f);
            }
        }
    }
}