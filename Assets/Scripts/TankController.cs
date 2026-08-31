using UnityEngine;

public class TankController : MonoBehaviour
{
    [Header("Movement Settings")]
    public float movementSpeed = 5.0f;
    public float rotationSpeed = 100.0f;

    [Header("Shooting Settings")]
    public GameObject shellPrefab;       // Your blue Shell template will go here
    public Transform fireTransform;      // Your FireTransform spawn point will go here
    public float launchForce = 15.0f;    // How fast the bullet shoots forward

    void Update()
    {
        // Handle tank driving movement
        float moveInput = Input.GetAxis("Vertical");
        float turnInput = Input.GetAxis("Horizontal");

        Vector3 moveDirection = Vector3.forward * moveInput * movementSpeed * Time.deltaTime;
        transform.Translate(moveDirection);

        float turnAmount = turnInput * rotationSpeed * Time.deltaTime;
        transform.Rotate(Vector3.up * turnAmount);

        // Handle spacebar weapon shooting
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Fire();
        }
    }

    void Fire()
    {
        // 1. Create a live duplicate of the bullet prefab right at the barrel tip
        GameObject newShell = Instantiate(shellPrefab, fireTransform.position, fireTransform.rotation);

        // 2. Fetch its Rigidbody physics component
        Rigidbody shellRb = newShell.GetComponent<Rigidbody>();

        // 3. Punch it forward out of the barrel with physics force
        if (shellRb != null)
        {
            shellRb.linearVelocity = fireTransform.forward * launchForce;
        }
    }
}
