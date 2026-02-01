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
    public GameObject mechaType; // Which mecha am I placing down?
    public float tileSize; // The size of the grid space (in meters)

    private GameObject ghostObject; // Will be the mecha type being placed
    private HashSet<Vector3> occupiedPosition = new HashSet<Vector3>(); // Use this to see which positions are occupied

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CreateGhost();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateGhost();

        if (Input.GetMouseButtonDown(0))
        {
            PlaceMecha();
        }
    }

    /// <summary>
    /// Create a ghost Object under the correct conditions
    /// </summary>
    private void CreateGhost()
    {
        ghostObject = Instantiate(mechaType);
        ghostObject.GetComponent<Collider>().enabled = false; // Allow it to move through placed objects

        Renderer[] renderers = ghostObject.GetComponentsInChildren<Renderer>();
        foreach (Renderer renderer in renderers)
        {
            Material mat = renderer.material;
            Color color = mat.color;
            color.a = 0.5f; // Slight Translucency
            mat.color = color;

            // Set up Rendering Engine
            mat.SetFloat("_Mode", 2);
            mat.SetInt("_ScrBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
            mat.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
            mat.SetInt("_ZWrite", 0);
            mat.DisableKeyword("_ALPHATEST_ON");
            mat.EnableKeyword("_ALPHABLEND_ON");
            mat.DisableKeyword("_ALPHAPREMULTIPLY_ON");
            mat.renderQueue = 3000;
        }
    }

    /// <summary>
    /// When the object is on the field, update its position as the player taps or drags their finger across the screen
    /// </summary>
    private void UpdateGhost()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); // Update to phones as we develop

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            Vector3 point = hit.point;

            Vector3 snappedPosition = new Vector3(
                Mathf.Round(point.x/tileSize)*tileSize,
                Mathf.Round(point.y/tileSize)*tileSize,
                Mathf.Round(point.z/tileSize)*tileSize
                ); // Today I learned this is possible. No more giant lines of text

            ghostObject.transform.position = snappedPosition;

            if (occupiedPosition.Contains(snappedPosition))
                SetGhostColor(Color.red);
            else SetGhostColor(new Color(1f, 1f, 1f, 0.5f)); // Keep color as is if the space is vacant
        }
    }

    /// <summary>
    /// What happens if the given space is occupied by another thing?
    /// </summary>
    /// <param name="color"></param>
    private void SetGhostColor(Color color)
    {
        Renderer[] renderers = ghostObject.GetComponentsInChildren<Renderer>();

        foreach (Renderer renderer in renderers)
        {
            Material mat = renderer.material;
            mat.color = color;
        }
    }

    /// <summary>
    /// Once the player taps the screen, a mech will be placed at the position
    /// </summary>
    void PlaceMecha()
    {
        Vector3 placementPos = ghostObject.transform.position; // Place the object at the ghost

        if (!occupiedPosition.Contains(placementPos))
        {
            Instantiate(mechaType, placementPos, Quaternion.identity);

            occupiedPosition.Add(placementPos);
        }
    }
}
