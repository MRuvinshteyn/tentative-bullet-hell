using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpeed : ProjectileModifier
{
    public ProjectileSpeed()
    {
        Name = Constants.PROJECTILE_SPEED;
        IsInitialModifier = true;
    }

    public override void ApplyModifier(Projectile target)
    {
        target.GetComponent<Rigidbody>().velocity *= 1.15f;
    }
}
