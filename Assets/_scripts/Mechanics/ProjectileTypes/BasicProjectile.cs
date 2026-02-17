using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Name: Ian Phurchpean
 * Date: 4 February 2026
 * Objective: Basic Mecha Projectile.
 */

public class BasicProjectile : MonoBehaviour
{
    // Initialize Variables
    [SerializeField] private float projectileSpeed; // Speed of projectile
    public float projectileDamage = 1f;

    public MechHealth mech;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Invoke("RemoveProjectile", 5);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * (projectileSpeed + mech.speedModifier) * Time.deltaTime); // The projectile moves forward
    }

    private void RemoveProjectile()
    {
        Destroy(gameObject); // Deload object to prevent lagspikes
    }
}

// Bingus