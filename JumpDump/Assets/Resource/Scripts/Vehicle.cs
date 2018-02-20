using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehicle : MonoBehaviour
{
    // Use this for initialization
    private void Start()
    {
    }

    // Update is called once per frame
    private IEnumerator MoveForward()
    {
        while (true)
        {
            //transform.position = Vector3.MoveTowards(transform.position, )
        }

        yield return null;
    }
}