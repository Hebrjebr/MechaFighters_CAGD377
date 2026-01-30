using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

/*
 * Name: Ian Phurchpean
 * Date: 29 January 2026
 * Objective: Basic Alien Behaviour script that can be implemented into multiple alien types
 */

public class AlienBehaviour : MonoBehaviour
{
    public float alienHealth = 10; // Can be changed
    public int alienDamage = 1; // Can be changed
    public Text healthDisplay;

    Coroutine damage;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        healthDisplay = GetComponent<Text>();
    }

    // Update is called once per frame
    // Update is called once per frame
    void Update()
    {
        // Reduce health every second
        damage = StartCoroutine(DamageTest());
        if (alienHealth <= 0) Destroy(gameObject);
    }

    IEnumerator DamageTest()
    {
        alienHealth -= 1 * Time.deltaTime;
        print("Alien Health decreasing");
        yield return new WaitForSeconds(2f);
    }
}
