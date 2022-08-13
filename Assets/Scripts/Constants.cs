using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Constants
{
    #region Layers

    public const int LAYER_PLAYER = 6;
    public const int LAYER_ENEMY = 7;
    public const int LAYER_PLAYER_PROJECTILE = 8;
    public const int LAYER_ITEM = 10;

    #endregion

    #region Base Values

    public const float BASE_PROJECTILE_SPEED = 10.00f;
    public const float BASE_PLAYER_SPEED = 5.00f;
    public const float BASE_ENEMY_SPEED = 1.00f;
    public const int BASE_MODIFIER_COUNT = 1;
    public const float BASE_INVINCIBILITY_TIME = 3.0f;
    public const float BASE_FIRE_RATE = 0.5f;

    #endregion

    #region Modifier Names

    public const string GENERIC_PROJECTILE_MODIFIER = "Generic Projectile Modifier";
    public const string PROJECTILE_SPEED = "Projectile Speed";
    public const string PROJECTILE_DAMAGE = "Projectile Damage";

    #endregion
}
