using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ProjectileModifier : Modifier<Projectile>
{
    public bool IsInitialModifier { get; set; }
}
