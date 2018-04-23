using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    public Vector3 Direction { get; set; }

    public float Range { get; set; }

    public int Damage { get; set; }

    private Vector3 spawnPosition;

    private void Start()
    {
        Range = 20f;
        Damage = 4;

        spawnPosition = this.transform.position;

        this.GetComponent<Rigidbody>().AddForce(Direction * 50f);
    }

    public void Update()
    {
        if (Vector3.Distance(spawnPosition, this.transform.position) >= Range)
        {
            Extinguish();
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Enemy")
        {
            collision.transform.GetComponent<IEnemy>().TakeDamage(Damage);
        }
        //어디든 부딪치면
        Extinguish();
    }

    private void Extinguish()
    {
        Destroy(gameObject);
    }
}