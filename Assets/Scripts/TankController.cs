using UnityEngine;

public class TankController : MonoBehaviour
{
    public float movementSpeed = 5.0f;
    public float rotationSpeed = 100.0f;

    void Update()
    {
        // Gathers input from W/S (Vertical) and A/D (Horizontal)
        float moveInput = Input.GetAxis("Vertical");
        float turnInput = Input.GetAxis("Horizontal");

        // Drive the tank forward or backward
        Vector3 moveDirection = Vector3.forward * moveInput * movementSpeed * Time.deltaTime;
        transform.Translate(moveDirection);

        // Turn the tank left or right smoothly
        float turnAmount = turnInput * rotationSpeed * Time.deltaTime;
        transform.Rotate(Vector3.up * turnAmount);
    }
}
