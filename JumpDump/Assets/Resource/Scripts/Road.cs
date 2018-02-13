using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum RoadType
{
    WATER,
    WALKWAY,
    RAILROAD,
    ROADWAY
}

public class Road : MonoBehaviour
{
    [SerializeField]
    private RoadType roadType;

    public RoadType RoadType
    {
        get
        {
            return roadType;
        }
    }

    private void Start()
    {
    }

    private void Update()
    {
    }
}