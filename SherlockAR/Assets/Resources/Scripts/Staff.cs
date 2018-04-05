﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Staff : MonoBehaviour, IWeapon, IProjectileWeapon
{
    private Animator animator;

    public List<BaseStat> Stats { get; set; }

    public Transform ProjectileSpawn { get; set; }

    public int CurrentDamage { get; set; }

    private Fireball fireball;

    private void Start()
    {
        fireball = Resources.Load<Fireball>("Weapons/Projectiles/Fireball");

        animator = GetComponent<Animator>();
    }

    public void PerformAttack(int damage)
    {
        animator.SetTrigger("Base_Attack");
    }

    public void PerformSpecialAttack()
    {
        animator.SetTrigger("Special_Attack");
    }

    public void CastProjectile()
    {
        Fireball fireballInstance = (Fireball)Instantiate(fireball, ProjectileSpawn.position, ProjectileSpawn.rotation);

        fireballInstance.Direction = ProjectileSpawn.forward;
    }
}