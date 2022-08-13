using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public List<ProjectileModifier> InitialModifiers;
    public List<ProjectileModifier> Modifiers;

    public float Damage { get; set; }
    public int MaxHits { get; set; }

    private int numHits;

    // Start is called before the first frame update
    void Start()
    {
        // prevent collision with player
        Physics.IgnoreLayerCollision(Constants.LAYER_PLAYER, Constants.LAYER_PLAYER_PROJECTILE);

        Damage = 4.0f;
        MaxHits = 1;
        numHits = 0;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void ApplyInitialModifiers()
    {
        for (int i = 0; i < InitialModifiers.Count; ++i)
        {
            InitialModifiers[i].ApplyModifier(this);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == Constants.LAYER_ENEMY &&
            numHits < MaxHits)
        {
            for (int i = 0; i < Modifiers.Count; ++i)
            {
                Modifiers[i].ApplyModifier(this);
            }

            collision.gameObject.GetComponent<Enemy>().UpdateHealth(-Damage);
            numHits++;
        }

        Destroy(gameObject);
    }
}
