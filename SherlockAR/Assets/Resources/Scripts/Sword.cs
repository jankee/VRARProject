using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour, IWeapon
{
    private Animator animator;

    public List<BaseStat> Stats { get; set; }

    public CharacterStats CharacterStats { get; set; }

    public void Start()
    {
        animator = this.GetComponent<Animator>();
    }

    public void performAttack()
    {
        animator.SetTrigger("Base_Attack");
    }

    public void PerformSpecialAttack()
    {
        animator.SetTrigger("Special_Attack");
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            print("Power : " + BaseStat.BaseStatType.Power);

            other.GetComponent<IEnemy>().TakeDamage(CharacterStats.GetStat(BaseStat.BaseStatType.Power).GetCalculatedStatValue());
        }
    }
}