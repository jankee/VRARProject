using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transport : Photon.MonoBehaviour
{
    private Transform parent;

    private Vector3 start;

    private Vector3 end;

    private float speed;

    private int dir;

    public void SetupParent(int roadID)
    {
        photonView.RPC("SetupParentRPC", PhotonTargets.AllBuffered, roadID);
    }

    [PunRPC]
    public void SetupParentRPC(int roadId)
    {
        PhotonView pv = PhotonView.Find(roadId);

        this.transform.SetParent(pv.transform);

        //if (PhotonNetwork.isMasterClient)
        //{
        //    this.transform.SetParent(pv.transform);
        //}
    }

    public void MoveForward(Vector3 start, Vector3 end, float speed, int dir)
    {
        this.start = start;
        this.end = end;
        this.speed = speed;
        this.dir = dir;

        photonView.RPC("StartRoutine", PhotonTargets.All);
    }

    [PunRPC]
    public void StartRoutine()
    {
        StartCoroutine(MoveForwardRPC(this.speed, this.dir));
    }

    public IEnumerator MoveForwardRPC(float speed, int dir)
    {
        if (dir == -1)
        {
            while (transform.position.x > end.x)
            {
                transform.Translate(Vector3.forward * speed * Time.deltaTime);

                yield return null;
            }
        }
        else
        {
            while (transform.position.x < end.x)
            {
                transform.Translate(Vector3.forward * speed * Time.deltaTime);

                yield return null;
            }
        }

        if (PhotonNetwork.isMasterClient)
        {
            PhotonNetwork.Destroy(gameObject);
        }
    }
}