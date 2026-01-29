using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

/*
 * Name: Ian Phurchpean
 * Date: 29 January 2026
 * Objective: Basic Mecha Behaviour script that can be implemented into multiple alien types
 */

public class MechHealth : MonoBehaviour
{
    public int mechHealth = 2; // Can be changed
    public int mechDamage = 1; // Can be changed
    public Text healthDisplay;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        healthDisplay = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        // Reduce health manually for testing
        if (Input.GetKey(KeyCode.E))
        {
            print ("Mech Health Reduced");
            mechHealth--;
        }
        if (mechHealth == 0) Destroy(gameObject);
    }
}
