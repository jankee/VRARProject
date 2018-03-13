using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehicle : MonoBehaviour
{
    // Update is called once per frame
    public IEnumerator MoveForward(Vector3 start, Vector3 end, float speed, int dir)
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

        Destroy(gameObject);
    }
}