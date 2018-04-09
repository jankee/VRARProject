using System.Collections;
using System.Collections.Generic;

public interface IEnemy
{
    Spawner Spawner { get; set; }

    int Experience { get; set; }

    void Die();

    void TakeDamage(int amount);

    void PerformAttack();
}