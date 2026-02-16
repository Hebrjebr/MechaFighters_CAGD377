using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/*
 * Name: Ian Phurchpean
 * Date: 29 January 2026
 * Objective: Basic Mecha Behaviour script that can be implemented into multiple alien types
 */

public class MechHealth : MonoBehaviour
{
    public float mechHealth = 5; // Can be changed
    public int mechDamage = 1; // Can be changed

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (mechHealth <= 0) Destroy(this.gameObject);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.GetComponent<Hitbox>())
        {
            mechHealth -= 1 * Time.deltaTime;
        }
    }
}
