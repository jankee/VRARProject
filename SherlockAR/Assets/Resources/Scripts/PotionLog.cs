using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionLog : MonoBehaviour, IConsumable
{
    public void Consume()
    {
        print("You drink a swig of the potion. cool!");
    }

    public void Consume(CharacterStats stats)
    {
        print("You drink a swig of the potion. Rad!");
    }
}