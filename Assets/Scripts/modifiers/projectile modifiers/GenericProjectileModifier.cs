using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericProjectileModifier : ProjectileModifier
{
    public GenericProjectileModifier()
    {
        Name = Constants.GENERIC_PROJECTILE_MODIFIER;
    }

    public override void ApplyModifier(Projectile target)
    {
        base.ApplyModifier(target);
    }
}
