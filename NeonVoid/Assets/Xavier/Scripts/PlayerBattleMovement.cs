using UnityEngine;

public class PlayerBattleMovement : MonoBehaviour
{
    public Transform player; // Player's transform
    public Transform[] points; // Store point transforms

    private Vector3 targetPosition = Vector3.zero; // Target position
    private float moveSpeed = 5f; // Movement speed

    void Update()
    {
        // Check for mouse click
        if (Input.GetMouseButtonDown(0))
        {
            // Get the mouse position in world space
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                Vector3 clickPosition = hit.point;
                MoveToClosestPoint(clickPosition);
            }
        }

        // Move player towards target position if there is a target set
        MovePlayer();
    }

    void MoveToClosestPoint(Vector3 position)
    {
        int closestPointIndex = FindClosestPointIndex(position);
        targetPosition = points[closestPointIndex].position;
    }

    void MovePlayer()
    {
        if (targetPosition != Vector3.zero)
        {
            player.position = Vector3.MoveTowards(player.position, targetPosition, moveSpeed * Time.deltaTime);

            // Check if player has reached the target position
            if (Vector3.Distance(player.position, targetPosition) < 0.1f)
            {
                targetPosition = Vector3.zero; // Reset target position once reached
            }
        }
    }

    int FindClosestPointIndex(Vector3 position)
    {
        int closestIndex = 0;
        float closestDistance = Mathf.Infinity;

        // Find closest point to the clicked position
        for (int i = 0; i < points.Length; i++)
        {
            float distance = Vector3.Distance(position, points[i].position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestIndex = i;
            }
        }

        return closestIndex;
    }
}