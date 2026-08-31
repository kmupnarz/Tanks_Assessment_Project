using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [Header("Tracking Settings")]
    public Transform playerTransform;    // Slot to link your green Player Tank
    public float movementSpeed = 3.5f;   // Driving speed
    public float rotationSpeed = 90.0f;  // Turning speed

    [Header("Combat Settings")]
    public GameObject shellPrefab;       // Your blue Shell template will go here
    public Transform fireTransform;      // The enemy's FireTransform barrel tip
    public float launchForce = 15.0f;    // Speed of enemy bullet
    public float fireRate = 2.0f;        // How many seconds between shots

    private float nextFireTime;          // Tracks weapon cooldown timer

    void Update()
    {
        // Safety check: Only execute if the player tank exists
        if (playerTransform != null)
        {
            // 1. Calculate direction and turn smoothly toward the player tank
            Vector3 targetDirection = playerTransform.position - transform.position;
            targetDirection.y = 0; // Keep the tank flat on the floor plane

            if (targetDirection != Vector3.zero)
            {
                Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            }

            // 2. Drive straight forward toward the player position
            transform.Translate(Vector3.forward * movementSpeed * Time.deltaTime);

            // 3. Automated shooting timer check
            if (Time.time >= nextFireTime)
            {
                EnemyFire();
                nextFireTime = Time.time + fireRate; // Set next cooldown timestamp
            }
        }
    }

    void EnemyFire()
    {
        // Safety check for empty slot assignments
        if (shellPrefab != null && fireTransform != null)
        {
            // Instantiate shell at enemy barrel tip coordinates
            GameObject newShell = Instantiate(shellPrefab, fireTransform.position, fireTransform.rotation);

            Rigidbody shellRb = newShell.GetComponent<Rigidbody>();
            if (shellRb != null)
            {
                shellRb.linearVelocity = fireTransform.forward * launchForce;
            }
        }
    }
}
