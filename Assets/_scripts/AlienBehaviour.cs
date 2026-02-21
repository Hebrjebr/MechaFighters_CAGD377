using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/*
 * Name: Ian Phurchpean
 * Date: 29 January 2026
 * Objective: Basic Alien Behaviour script that can be implemented into multiple alien types
 */

public class AlienBehaviour : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private float alienSpeed; // How fast does the alien move?
    public GameManager gm;
    public Rigidbody rb;
    public MechHealth mech;

    [Header("Attributes")]
    public float alienHealth = 10f; // How many hits can the alien take?
    public float alienDamage = 1f; // How much damage does the alien do per hit?
    public float range = 0.5f;

    public bool canMove = true;

    [Header("Drops")]
    public GameObject[] dropPrefab;
    [SerializeField] private int randDrop = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        randDrop = Random.Range(1, 10);
    }

    void Update()
    {
        if (canMove == true)
        {
            AlienMovement();
        }

        if (alienHealth <= 0)
        {
            if (randDrop <= 3)
            {
                randDrop = Random.Range(0, dropPrefab.Length); // Which Item?
                if (randDrop < dropPrefab.Length)
                {
                    // Drop the item
                    GameObject newDrop = Instantiate(dropPrefab[randDrop], transform.position, transform.rotation);
                    Debug.Log("Enemy Drops Item " + randDrop + 1); // Debug
                }
            }
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        
    }

    /// <summary>
    /// Alien Moves slowly towards the left side of the screen
    /// </summary>
    private void AlienMovement()
    {
        transform.position -= new Vector3(alienSpeed, 0, 0);
    }

    /// <summary>
    /// Detect collision with other objects
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        // Basic Projectile
        if (other.gameObject.GetComponent<BasicProjectile>())
        {
            print("Alien has lost health");
            alienHealth -= 1;
            Destroy(other.gameObject);
        }
        // Coal Projectile
        else if (other.gameObject.GetComponent<CoalProjectile>())
        {
            print("Alien has taken massive damage");
            alienHealth -= 5;
            Destroy(other.gameObject);
        }
    }
}
