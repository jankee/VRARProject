using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Staff : MonoBehaviour, IWeapon, IProjectileWeapon
{
    private Animator animator;

    public List<BaseStat> Stats { get; set; }

    public Transform ProjectileSpawn { get; set; }

    public int CurrentDamage { get; set; }

    private FireBall fireBall;

    public void Start()
    {
        fireBall = Resources.Load<FireBall>("Weapons/Projectiles/Fireball");

        animator = this.GetComponent<Animator>();
    }

    public void performAttack(int damage)
    {
        animator.SetTrigger("Base_Attack");
    }

    public void PerformSpecialAttack()
    {
        animator.SetTrigger("Special_Attack");
    }

    public void CastProjectile()
    {
        FireBall fireballInstance = Instantiate(fireBall, ProjectileSpawn.position, ProjectileSpawn.rotation);

        fireballInstance.Direction = ProjectileSpawn.forward;

        fireballInstance.Damage = CurrentDamage;
    }
}