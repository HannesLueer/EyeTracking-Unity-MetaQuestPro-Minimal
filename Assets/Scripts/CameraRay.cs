using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRay : MonoBehaviour
{
    [SerializeField]
    private LayerMask layersToInclude;

    [SerializeField]
    private GameObject centerEyeAnchor;

    [SerializeField]
    private bool drawDebugLine;

    LineDrawer lineDrawer;
    float rayDistance = 10000.0f;

    private List<Highlighter> highlightables = new List<Highlighter>();

    // Start is called before the first frame update
    void Start()
    {
        lineDrawer = new LineDrawer();
    }

    // Update is called once per frame
    void Update()
    {
        // get values
        Vector3 headPosition = centerEyeAnchor.transform.position;
        Quaternion headRotation = centerEyeAnchor.transform.rotation;

        Vector3 start = headPosition;
        Vector3 end = headRotation * Vector3.forward * rayDistance;

        // draw line
        if (drawDebugLine)
        {
            lineDrawer.DrawLineInGameView(start, end, Color.red);
        }

        // hit
        RaycastHit hit;
        if (Physics.Raycast(start, end, out hit, Mathf.Infinity, layersToInclude))
        {
            UnSelect();
            var highlightable = hit.transform.GetComponent<Highlighter>();


            if (highlightable != null)
            {
                highlightables.Add(highlightable);
                highlightable.IsHovered = true;
            }

        }
        else
        {
            UnSelect(true);
        }
    }

    void UnSelect(bool clear = false)
    {
        foreach (var highlightable in highlightables)
        {
            highlightable.IsHovered = false;
        }
        if (clear)
        {
            highlightables.Clear();
        }
    }
}
