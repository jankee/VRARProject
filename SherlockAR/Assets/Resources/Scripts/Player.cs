using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public CharacterStats characterStats;

    private void Start()
    {
        characterStats = new CharacterStats(2, 5, 8);
    }

    // Update is called once per frame
    private void Update()
    {
    }
}