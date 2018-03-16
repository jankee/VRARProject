using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transport : Photon.MonoBehaviour
{
    public void MoveForward(Vector3 start, Vector3 end, float speed, int dir)
    {
        photonView.RPC("MoveForwardRPC", PhotonTargets.AllViaServer, start, end, speed, dir);
    }

    [PunRPC]
    public IEnumerator MoveForwardRPC(Vector3 start, Vector3 end, float speed, int dir)
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

        PhotonNetwork.Destroy(gameObject);
    }
}