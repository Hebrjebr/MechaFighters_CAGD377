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
    public float alienHealth = 10; // How many hits can the alien take?
    public float aliensDestroyed = 0;
    public float alienDamage = 1; // How much damage does the alien do per hit?
    public Rigidbody rb;

    public GameManager gm;
    public int alienScore;

    [Header("Drops")]
    public GameObject[] dropPrefab;
    [SerializeField] private int randDrop = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        randDrop = Random.Range(1, 10);
    }

    private void FixedUpdate()
    {
        transform.position -= new Vector3(alienSpeed, 0, 0);
    }

    private void OnDestroy()
    {
        aliensDestroyed++;
    }

    /// <summary>
    /// Detect collision with other objects
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<BasicProjectile>())
        {
            print("Alien has lost health");
            alienHealth -= 1;
            Destroy(other.gameObject);
        }
        if (alienHealth <= 0)
        {
            gm.alienCount++;
            gm.alienTotal += alienScore;
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
}
