using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private GameObject monster;

    [SerializeField]
    private bool respawn;

    [SerializeField]
    private float spawnDelay;

    private float currentTime;

    private bool spawning;

    // Use this for initialization
    private void Start()
    {
        Spawn();
        currentTime = spawnDelay;
    }

    // Update is called once per frame
    private void Update()
    {
        if (spawning)
        {
            currentTime -= Time.deltaTime;

            if (currentTime <= 0)
            {
                Spawn();
            }
        }
    }

    public void Respawn()
    {
        spawning = true;

        currentTime = spawnDelay;
    }

    private void Spawn()
    {
        IEnemy instance = Instantiate(monster, transform.position, Quaternion.identity).GetComponent<IEnemy>();
        instance.Spawner = this;
        spawning = false;
    }
}