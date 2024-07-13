using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : Health
{
    protected override void Update()
    {
        base.Update();
    }

    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
    }

    public override void TakeHealing(int healPoints)
    {
        base.TakeHealing(healPoints);
    }

    protected override void Die()
    {
        base.Die();
    }
}
