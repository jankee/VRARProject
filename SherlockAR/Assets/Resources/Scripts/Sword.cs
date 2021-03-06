﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour, IWeapon
{
    private Animator animator;

    public List<BaseStat> Stats { get; set; }

    public CharacterStats CharacterStats { get; set; }

    public int CurrentDamage { get; set; }

    public void Start()
    {
        animator = this.GetComponent<Animator>();
    }

    public void Update()
    {
        if (CharacterStats != null)
        {
            print(CharacterStats.stats.Count);
        }
    }

    public void performAttack(int damage)
    {
        CurrentDamage = damage;

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
            other.GetComponent<IEnemy>().TakeDamage(CurrentDamage);
        }
    }
}