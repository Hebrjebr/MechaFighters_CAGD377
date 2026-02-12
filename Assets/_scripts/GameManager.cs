using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/*
 * Name: Ian Phurchpean
 * Date: 12 February 2026
 * Objective: Game Manager.
 */

public class GameManager : MonoBehaviour
{
    // Initialize Variables
    public int alienCount = 0;
    public int alienTotal = 0;
    public TMP_Text alienText;
    public TMP_Text alienScore;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        alienText.text = "Aliens Defeated: " + alienCount.ToString();
        alienScore.text = "Score: " + alienTotal.ToString();
    }
}
