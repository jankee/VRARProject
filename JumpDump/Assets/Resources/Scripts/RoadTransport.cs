using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadTransport : Road
{
    [SerializeField]
    private GameObject[] transports;

    [SerializeField]
    private Vector2 repeatChance = new Vector2(0, 10);

    [SerializeField]
    private float repeatTime;

    private GameObject newTransport;

    private Animator anim;

    // Use this for initialization
    protected override void Start()
    {
        base.Start();

        //photonView = GetComponent();

        //randomTime.x = Random.Range(randomTime.x, randomTime.y);

        if (PhotonNetwork.isMasterClient)
        {
            anim = GetComponent<Animator>();

            StartCoroutine(ProcessRoutine());

            if (MoveDirection == -1)
            {
                StartCoroutine(CreateTransport(LaneEnd, LaneStart));
            }
            else
            {
                StartCoroutine(CreateTransport(LaneStart, LaneEnd));
            }
        }
    }

    public void InitRoad()
    {
        photonView.RPC("InitRoadRPC", PhotonTargets.AllBuffered);
    }

    [PunRPC]
    private void InitRoadRPC()
    {
        //이런식으로는
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

            newTransport = PhotonNetwork.Instantiate("Prefabs/" + transports[selNum].name, this.transform.position + start, Quaternion.identity, 0);

            if (PhotonNetwork.isMasterClient)
            {
                //서버동기화
                photonView.RPC("TransportSet", PhotonTargets.AllBuffered, start, end);
            }
        }
    }

    //private void OnPhotonInstatiate(PhotonMessageInfo info, int selNum)
    //{
    //    newTransport = this.transports[selNum].gameObject;
    //}

    [PunRPC]
    private void TransportSet(Vector3 start, Vector3 end)
    {
        //부모설정이 안되서 옮김
        //newTransport.transform.SetParent(this.transform);
        if (PhotonNetwork.isMasterClient)
        {
            int roadID = photonView.viewID;

            //운송 수단의 부모셋업
            newTransport.GetComponent<Transport>().SetupParent(roadID);

            newTransport.transform.LookAt(this.transform.position + end);

            //재 시작되는 값을 랜덤하게 생성
            newTransport.GetComponent<Transport>().MoveForward(start, end, MoveSpeed.x, MoveDirection);
        }
    }

    // Update is called once per frame
    private IEnumerator ProcessRoutine()
    {
        if (PhotonNetwork.isMasterClient)
        {
            while (true)
            {
                int randomNum = (int)Random.Range(this.repeatChance.x, this.repeatChance.y);

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
                yield return new WaitForSeconds(repeatTime);
            }
        }
    }
}