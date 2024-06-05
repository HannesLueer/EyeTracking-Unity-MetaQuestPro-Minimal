using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRay : MonoBehaviour
{
    [SerializeField]
    private LayerMask layersToInclude;

    [SerializeField]
    private GameObject leftEyeAnchor;

    [SerializeField]
    private GameObject rightEyeAnchor;

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
        Vector3 leftEyePosition = leftEyeAnchor.transform.position;
        Quaternion leftEyeRotation = leftEyeAnchor.transform.rotation;
        Vector3 rightEyePosition = rightEyeAnchor.transform.position;
        Quaternion rightEyeRotation = rightEyeAnchor.transform.rotation;

        // calculate average
        Vector3 avgEyePosition = (leftEyePosition + rightEyePosition) / 2;
        Quaternion avgEyeRotation = Quaternion.Lerp(leftEyeRotation, rightEyeRotation, .1f);

        // set start and end
        Vector3 start = avgEyePosition;
        Vector3 end = avgEyeRotation * Vector3.forward * rayDistance;

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
