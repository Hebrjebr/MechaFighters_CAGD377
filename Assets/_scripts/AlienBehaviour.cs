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
    [SerializeField] private float alienSpeed; // How fast does the alien move?
    public float alienHealth = 10; // How many hits can the alien take?

    public float alienDamage = 1; // How much damage does the alien do per hit?

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        transform.position -= new Vector3(alienSpeed, 0, 0);
        if (alienHealth <= 0) Destroy(gameObject); // When health at most 0, destroy
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
    }
}
