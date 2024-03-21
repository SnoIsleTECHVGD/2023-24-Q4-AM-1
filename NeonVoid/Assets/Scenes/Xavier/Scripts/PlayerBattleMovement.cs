using UnityEngine;

public class PlayerBattleMovement : MonoBehaviour
{
    public Transform player; // Player's transform
    public Vector3[] points; // Store points


    private int currentPointIndex = 0; // Current point
    private Vector3 targetPosition; // Target position
    private float moveSpeed = 5f; // Movement speed


    void Start()
    {
        // Set initial target pos to the first point
        targetPosition = points[currentPointIndex];
    }


    void Update()
    {
        // Mouse click
        if (Input.GetMouseButtonDown(0))
        {
            // Cam raycast
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;


            if (Physics.Raycast(ray, out hit))
            {
                // Find closest point to hit point
                int closestPointIndex = FindClosestPointIndex(hit.point);


                // If the closest point is different from current point move to the new point
                if (closestPointIndex != currentPointIndex)
                {
                    currentPointIndex = closestPointIndex;
                    targetPosition = points[currentPointIndex];
                }
            }
        }


        // Move player towards target position
        player.position = Vector3.MoveTowards(player.position, targetPosition, moveSpeed * Time.deltaTime);
    }


    int FindClosestPointIndex(Vector3 position)
    {
        int closestIndex = 0;
        float closestDistance = Mathf.Infinity;


        // Find closest point to pos
        for (int i = 0; i < points.Length; i++)
        {
            float distance = Vector3.Distance(position, points[i]);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestIndex = i;
            }
        }


        return closestIndex;
    }
}
