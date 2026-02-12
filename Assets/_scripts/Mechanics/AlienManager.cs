using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class AlienManager : MonoBehaviour
{
    // Initialize Variables
    public AlienBehaviour aliens; // Reference to the aliens destroyed by the player
    public TMP_Text alienCount;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        alienCount.text = "Aliens Destroyed: " + aliens.aliensDestroyed.ToString();
    }
}
