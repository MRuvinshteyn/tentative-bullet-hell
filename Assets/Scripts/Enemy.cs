using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Enemy : MonoBehaviour
{
    public GameObject ModifierPrefab;
    public GameObject DamageTextPrefab;

    protected float targetX, targetY;
    protected float health;
    Transform player;

    string[] dropTable;
    float dropChance;

    // Start is called before the first frame update
    void Start()
    {
        InitializeVariables();
    }

    // Update is called once per frame
    void Update()
    {
        CheckDeath();

        UpdateVariables();
        UpdateAction();
    }

    /// <summary>
    /// If the enemy loses all of its health, destroy it.
    /// If the enemy drops an item on death, spawn it in its place.
    /// </summary>
    private void CheckDeath()
    {
        if (health <= 0.0f)
        {
            System.Random rand = new System.Random();

            if (dropTable.Length > 0 && rand.NextDouble() <= dropChance)
            {
                GameObject newModifier = Instantiate(ModifierPrefab, new Vector3(transform.position.x, transform.position.y, 0), transform.rotation);

                int index = rand.Next(dropTable.Length);
                newModifier.GetComponent<ModifierWrapper>().Name = dropTable[index];
            }

            Destroy(gameObject);
        }
    }

    /// <summary>
    /// Update the health of the current enemy.
    /// </summary>
    /// <param name="amount">The amount of health to add</param>
    public void UpdateHealth(float amount)
    {
        health += amount;

        if (amount < 0)
        {
            GameObject damageText = Instantiate(DamageTextPrefab, new Vector3(transform.position.x, transform.position.y, 0), new Quaternion());
            damageText.GetComponentInChildren<TextMeshPro>().text = -amount + "";
        }
    }

    /// <summary>
    /// Initialize member variables.
    /// </summary>
    protected virtual void InitializeVariables()
    {
        player = GameObject.Find("player (temp)").transform;

        dropTable = new string[] { Constants.GENERIC_PROJECTILE_MODIFIER };
        dropChance = 0.5f;

        health = 10.0f;

        targetX = player.position.x;
        targetY = player.position.y;
    }

    /// <summary>
    /// Update member variables.
    /// </summary>
    protected virtual void UpdateVariables()
    {
        targetX = player.position.x;
        targetY = player.position.y;
    }

    /// <summary>
    /// Perform any actions on Update().
    /// </summary>
    protected virtual void UpdateAction()
    {
        float AngleRad = Mathf.Atan2(targetY - transform.position.y, targetX - transform.position.x);
        float AngleDeg = (180 / Mathf.PI) * AngleRad;

        transform.SetPositionAndRotation(new Vector3(transform.position.x, transform.position.y, 0), Quaternion.Euler(0, 0, AngleDeg));

        Rigidbody rb = GetComponent<Rigidbody>();

        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }
}
