using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using System.Runtime.CompilerServices;

/*
 * Name: Ian Phurchpean
 * Date: 1 February 2026
 * Objective: Basic Alien Spawner to create aliens in waves that attack the player.
 */

public class AlienSpawner : MonoBehaviour
{
    public Transform[] spawners; // Define spawners
    public GameObject aliens; // Define aliens

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("SpawnAlien", 2, 5);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// This will spawn an alien at random from one of the spawners, and LATER spawn different types of aliens depending on the difficulty.
    /// </summary>
    private void SpawnAlien()
    {
        int r = Random.Range(0, spawners.Length); // Choose a spawnpoint at random for the aliens to spawn
        GameObject newAlien = Instantiate(aliens, spawners[r].position, Quaternion.identity); // Spawn an alien at random
    }
}
