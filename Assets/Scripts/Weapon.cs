using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject ProjectilePrefab;
    private float lastShotTime;

    //public List<WeaponModifier> WeaponModifiers;
    public List<ProjectileModifier> InitialModifiers;
    public List<ProjectileModifier> Modifiers;

    // Start is called before the first frame update
    void Start()
    {
        InitialModifiers = new List<ProjectileModifier>();
        Modifiers = new List<ProjectileModifier>();

        lastShotTime = -Constants.BASE_FIRE_RATE;
    }

    /// <summary>
    /// Create a new projectile using the prefab attached to this script
    /// </summary>
    public void CreateProjectile()
    {
        if (lastShotTime < Time.time - Constants.BASE_FIRE_RATE)
        {
            // create new projectile and apply initial modifiers
            GameObject newProjectile = Instantiate(ProjectilePrefab, new Vector3(transform.position.x, transform.position.y, 0), transform.rotation);
            newProjectile.GetComponent<Projectile>().InitialModifiers = this.InitialModifiers;
            newProjectile.GetComponent<Projectile>().Modifiers = this.Modifiers;

            // calculate velocity of new projectile
            var angle = GetComponent<Player>().transform.rotation.eulerAngles.z * Mathf.Deg2Rad;
            newProjectile.GetComponent<Rigidbody>().velocity
                = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0).normalized * Constants.BASE_PROJECTILE_SPEED;

            // apply initial modifiers to the newly created projectile
            newProjectile.GetComponent<Projectile>().ApplyInitialModifiers();

            lastShotTime = Time.time;
        }
    }

    public void AddModifier(ProjectileModifier modifier)
    {
        if (modifier.IsInitialModifier)
        {
            InitialModifiers.Add(modifier);
        }
        else
        {
            Modifiers.Add(modifier);
        }
    }
}
