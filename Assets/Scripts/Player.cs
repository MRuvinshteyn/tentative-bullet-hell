using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    public Weapon Weapon;
    public GameObject DamageTextPrefab;

    private float health;
    private float invincibilityTimer;

    // Start is called before the first frame update
    void Start()
    {
        Weapon = GetComponent<Weapon>();

        health = 5;
        invincibilityTimer = -Constants.BASE_INVINCIBILITY_TIME;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 1)
        {
            Vector2 mouseOnScreen = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            float AngleRad = Mathf.Atan2(mouseOnScreen.y - transform.position.y, mouseOnScreen.x - transform.position.x);
            float AngleDeg = (180 / Mathf.PI) * AngleRad;

            transform.rotation = Quaternion.Euler(0, 0, AngleDeg);

            Rigidbody rb = GetComponent<Rigidbody>();
            var moveHorizontal = Input.GetAxisRaw("Horizontal");
            var moveVertical = Input.GetAxisRaw("Vertical");

            rb.velocity = (moveHorizontal * Vector3.right + moveVertical * Vector3.up) * Constants.BASE_PLAYER_SPEED;
            rb.angularVelocity = Vector3.zero;

            if (Input.GetMouseButtonDown(0))
            {
                Weapon.CreateProjectile();
            }

            if (Input.GetMouseButtonDown(1))
            {
                // send raycast to check for interactable item
                Debug.DrawRay((Vector2)transform.position, mouseOnScreen - (Vector2)transform.position);

                RaycastHit hit;
                if (Physics.Raycast(transform.position, mouseOnScreen - (Vector2)transform.position, out hit))
                {
                    if (hit.collider.gameObject.layer == Constants.LAYER_ITEM)
                    {
                        Debug.Log(hit.collider.gameObject.name);

                        GetComponent<Weapon>().AddModifier(hit.collider.gameObject.GetComponent<ModifierWrapper>().ReturnNewInstance());
                        Debug.Log(string.Join(" -> ", GetComponent<Weapon>().Modifiers));

                        Destroy(hit.collider.gameObject);
                    }
                }
            }

            if (health <= 0)
            {
                // handle death
            }
        }
    }

    /// <summary>
    /// Handle collisions with various enemies/interactables.
    /// </summary>
    /// <param name="collision">Collision to act on</param>
    private void OnCollisionEnter(Collision collision)
    {
        // handle picking up a modifier
        if (collision.gameObject.layer == Constants.LAYER_ITEM)
        {
            Debug.Log(collision.gameObject.name);

            GetComponent<Weapon>().AddModifier(collision.gameObject.GetComponent<ModifierWrapper>().ReturnNewInstance());
            Debug.Log(string.Join(" -> ", GetComponent<Weapon>().Modifiers));

            Destroy(collision.gameObject);
        }

        // handle colliding with an enemy
        if (collision.gameObject.layer == Constants.LAYER_ENEMY &&
            invincibilityTimer < Time.time - Constants.BASE_INVINCIBILITY_TIME)
        {
            UpdateHealth(-1.0f);
            invincibilityTimer = Time.time;
        }
    }

    /// <summary>
    /// Update the health of the player.
    /// </summary>
    /// <param name="amount">The amount of health to add</param>
    public void UpdateHealth(float amount)
    {
        health += amount;

        if (amount < 0)
        {
            GameObject damageText = Instantiate(DamageTextPrefab, new Vector3(transform.position.x, transform.position.y, 0), new Quaternion());
            damageText.GetComponentInChildren<TextMeshPro>().faceColor = Color.red;
            damageText.GetComponentInChildren<TextMeshPro>().text = -amount + "";
        }
    }
}
