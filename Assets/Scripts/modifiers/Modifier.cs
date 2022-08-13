using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Modifier<T>
{
    // title of the modifier
    public string Name { get; set; }

    // object to which the modifier is attached
    public T Parent { get; set; }

    /// <summary>
    /// Apply the modifier's properties
    /// </summary>
    /// 
    /// <param name="projectile">
    /// The target to receive the modification
    /// </param>
    public virtual void ApplyModifier(T target)
    {

    }
}
