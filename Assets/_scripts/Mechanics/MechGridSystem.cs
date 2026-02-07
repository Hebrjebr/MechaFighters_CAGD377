using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Name: Ian Phurchpean
 * Date: 1 February 2026
 * Objective: This will enable mecha to be placed within a grid system on the board. We appear to be aiming for a 9*5 grid (9 units wide, 5 units tall)
 */

public class MechGridSystem : MonoBehaviour
{
    // Initialize Variables
    [Header("References")]
    public GameObject mechaPrefab, mecha;
    public Grid grid;
    public GridTestInput gridInput;

    private void Update()
    {
        Vector3 selectPos = gridInput.GetSelectedMapPosition();
        Vector3Int cellPos = grid.WorldToCell(selectPos);
        mecha.transform.position = grid.GetCellCenterWorld(cellPos);

        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(mechaPrefab, mecha.transform.position, Quaternion.identity);
        }
    }
}
