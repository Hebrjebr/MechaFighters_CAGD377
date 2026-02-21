using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Name: Ian Phurchpean
 * Date: 4 February 2026
 * Objective: Basic Guard Mech behavior.
 * Description: The Guard Mech is the basic mech the player obtains at the start of the game.
 * They receive an infinite amount of them, and function by shooting basic projectiles at opposing aliens in the lane.
 */

public class GuardMech : MonoBehaviour
{
    // Initialize Variables
    [Header("References")]
    public GameObject mechaProjectile;
    [SerializeField] private float fireDelay, fireRate, fireRange; // Serialize Field for testing
    public Transform targetObject;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Vector3 origin = transform.position;
        Vector3 direction = transform.forward * fireRange;

        RaycastHit hit;
        Debug.DrawRay(origin, direction, Color.green, fireRange);
        if (Physics.Raycast(origin, direction, out hit, fireRange) && (hit.collider.transform == targetObject))
        {
            InvokeRepeating("Projectile", fireDelay, fireRate); // Shoot
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Activate this whenever an Alien is in range
    /// </summary>
    private void Projectile()
    {
        GameObject projPrefab = Instantiate(mechaProjectile, transform.position, transform.rotation);
    }

}

// Bingus
