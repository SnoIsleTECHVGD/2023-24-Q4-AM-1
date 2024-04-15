using UnityEngine;

public class PlayerBattleMovement : MonoBehaviour
{
    public Transform player; 
    public Transform[] points;

    private Vector3 targetPosition = Vector3.zero; // Target position
    private float moveSpeed = 5f; // Movement speed
    private bool isMoving = false; // Player moving?

    void Update()
    {
        // Get input axes
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        // Movement direction vector
        Vector3 moveDirection = new Vector3(horizontal, 0f, vertical).normalized;

        // Limit diagonal speed, retur sqr value
        if (moveDirection.sqrMagnitude > 1f)
        {
            moveDirection.Normalize();
        }

        // Move to closest point
        if (moveDirection != Vector3.zero)
        {
            MoveToClosestPointInDirection(moveDirection);
        }

        MovePlayer();
    }

    void MoveToClosestPointInDirection(Vector3 direction)
    {
        int closestPointIndex = FindClosestPointInDirection(direction);
        targetPosition = points[closestPointIndex].position;
        isMoving = true; // Set moving to true
    }

    void MovePlayer()
    {
        if (isMoving)
        {
            player.position = Vector3.MoveTowards(player.position, targetPosition, moveSpeed * Time.deltaTime);

            // Check if player has reached the point
            if (Vector3.Distance(player.position, targetPosition) < 0.1f)
            {
                // isMoving = false; // Reset moving once at point
            }
        }
    }

    int FindClosestPointInDirection(Vector3 direction)
    {
        int closestIndex = 0;
        float closestDistance = Mathf.Infinity;

        // Find closest point in given direction
        for (int i = 0; i < points.Length; i++)
        {
            Vector3 pointDirection = (points[i].position - player.position).normalized;
            float dotProduct = Vector3.Dot(direction, pointDirection);
            if (dotProduct > 0f)
            {
                float distance = Vector3.Distance(player.position, points[i].position);
                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    closestIndex = i;
                }
            }
        }

        return closestIndex;
    }
}