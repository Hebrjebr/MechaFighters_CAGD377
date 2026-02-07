using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Name: Ian Phurchpean
 * Date: 6 February 2026
 * Objective: Grid to Camera
 */

public class GridTestInput : MonoBehaviour
{
    // Initialize Variables
    public Camera cam;
    public Vector3 lastPos;
    public LayerMask groundLayer;

    public Vector3 GetSelectedMapPosition()
    {
        Vector3 mousePos = Input.mousePosition; // Change to handheld later
        mousePos.z = cam.nearClipPlane;
        Ray raycast = cam.ScreenPointToRay(mousePos); // Once again, change to handheld
        RaycastHit hit;

        Debug.DrawRay(raycast.origin, raycast.direction * 100, Color.green);
        if (Physics.Raycast(raycast, out hit, 100, groundLayer))
        {
            lastPos = hit.point; // Change to fit handheld
        }
        return lastPos; // Return data
    }
}
