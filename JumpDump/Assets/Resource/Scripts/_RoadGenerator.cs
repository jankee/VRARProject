using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _RoadGenerator : MonoBehaviour
{
    private float timePlus = 0;

    // Use this for initialization
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        timePlus += 0.02f;

        print("Time : " + timePlus);
    }
}