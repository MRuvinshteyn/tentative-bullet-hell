using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModifierWrapper : MonoBehaviour
{
    public string Name;

    public ProjectileModifier ReturnNewInstance()
    {
        return ModifierDatabase.GetProjectileModifier(Name);
    }
}
