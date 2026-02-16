using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/*
 * Name: Ian Phurchpean
 * Date: 16 Februrary 2026
 * Objective: Hitbox Script
 */

public class Hitbox : MonoBehaviour
{
    // Get reference to alien hitbox
    public AlienBehaviour alien;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    { 

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<MechHealth>())
        {
            alien.canMove = false;
        }
    }
}
