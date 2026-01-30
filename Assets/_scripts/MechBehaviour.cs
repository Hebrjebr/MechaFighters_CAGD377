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
    public float mechHealth = 10; // Can be changed
    public int mechDamage = 1; // Can be changed
    public Text healthDisplay;

    Coroutine damage;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        healthDisplay = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        // Reduce health every second
        damage = StartCoroutine(DamageTest());
        if (mechHealth <= 0) Destroy(gameObject);
    }

    IEnumerator DamageTest()
    {
        mechHealth -= 1 * Time.deltaTime;
        print("Mech Health decreased");
        yield return new WaitForSeconds(2f);
    }
}
