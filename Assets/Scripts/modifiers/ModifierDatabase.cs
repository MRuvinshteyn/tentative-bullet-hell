using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ModifierDatabase
{
    public static Dictionary<string, ProjectileModifier> ProjectileModifiers = new Dictionary<string, ProjectileModifier>
        {
            { Constants.GENERIC_PROJECTILE_MODIFIER, new GenericProjectileModifier() },
            { Constants.PROJECTILE_SPEED, new ProjectileSpeed() },
            { Constants.PROJECTILE_DAMAGE, new ProjectileDamage() }
        };

    public static ProjectileModifier GetProjectileModifier(string name)
    {
        return ProjectileModifiers[name];
    }
}
