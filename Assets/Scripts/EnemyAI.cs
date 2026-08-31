using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Transform playerTransform;    // Slot to link your green Player Tank
    public float movementSpeed = 3.5f;   // Enemy drives a bit slower than the player
    public float rotationSpeed = 90.0f;  // Smooth turning speed

    void Update()
    {
        // Safety check: Make sure the script can see the player tank
        if (playerTransform != null)
        {
            // 1. Calculate the direction to the player tank
            Vector3 targetDirection = playerTransform.position - transform.position;
            targetDirection.y = 0; // Keep the tank flat on the ground floor

            // 2. Smoothly rotate the enemy to face toward the player
            if (targetDirection != Vector3.zero)
            {
                Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            }

            // 3. Constantly drive straight forward toward the player
            transform.Translate(Vector3.forward * movementSpeed * Time.deltaTime);
        }
    }
}
