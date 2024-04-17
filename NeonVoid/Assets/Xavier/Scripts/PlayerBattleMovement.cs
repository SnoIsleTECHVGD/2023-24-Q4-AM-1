using UnityEngine;
using UnityEngine.UI;

public class PlayerBattleMovement : MonoBehaviour
{
    public Transform player;
    public Transform[] points;

    public Button Card;


    private Vector3 targetPosition = Vector3.zero; // Target position
    private float moveSpeed = 5f; // Movement speed
    private bool isMoving = false; // Player moving?
    private float rotationSpeed = 90f; // Degrees per second

    void Update()
    {
        // Get input axes
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        // Rotate the player
        //RotatePlayer(horizontal);

        // Move to closest point if the point in front is detected
        //if (Input.GetButtonDown("Card"))
        //{
        //    MoveToClosestPointInDirection(player.forward);
        //}
        //else
        //{
        //    isMoving = false;
        //}

        MovePlayer();
    }

    public void MoveToClosestPointInDirection(Vector3 direction)
    {
        int closestPointIndex = FindClosestPointInDirection(direction);
        Vector3 closestPointPosition = points[closestPointIndex].position;
        if (CanMoveToPoint(closestPointPosition))
        {
            targetPosition = closestPointPosition;
            isMoving = true; // Set moving to true
        }
        else
        {
            isMoving = false; // Can't move to the point, so stop moving
        }
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

    bool CanMoveToPoint(Vector3 targetPosition)
    {
        RaycastHit hit;
        if (Physics.Raycast(player.position, (targetPosition - player.position).normalized, out hit, Vector3.Distance(player.position, targetPosition)))
        {
            // If the ray hits something, return false
            return false;
        }
        return true; // No obstacles, so the point is walkable
    }

    void RotatePlayer(float horizontal)
    {
        if (horizontal != 0f)
        {
            // Rotate the player based on the horizontal input
            player.Rotate(Vector3.up * horizontal * rotationSpeed * Time.deltaTime, Space.Self);
        }
    }
}