using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileDamage : ProjectileModifier
{
    public ProjectileDamage()
    {
        Name = Constants.PROJECTILE_DAMAGE;
    }

    public override void ApplyModifier(Projectile target)
    {
        target.Damage *= 1.25f;
    }
}
