using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionLog : MonoBehaviour, IConsumable
{
    public void Consume()
    {
        print("You drank a swig of the potion. cool!");
    }

    public void Consume(CharacterStats stats)
    {
        print("You drank a swig of the potion. Rad!");
    }
}