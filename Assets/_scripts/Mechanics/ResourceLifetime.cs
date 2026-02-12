using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/*
 * Name: Ian Phurchpean
 * Date: 11 February 2026
 * Objective: Destroy Object after a set time
 */

public class ResourceLifetime : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(Remove());
    }

    private IEnumerator Remove()
    {
        yield return new WaitForSeconds(10f);
        Destroy(gameObject);
    }
}
