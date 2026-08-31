using UnityEngine;

public class TankHealth : MonoBehaviour
{
    [Header("Health Settings")]
    public float maxHealth = 100f;
    private float currentHealth;

    void Start()
    {
        // Set health to full when the game starts
        currentHealth = maxHealth;
    }

    // This runs automatically when a physics shell bullet hits the tank
    void OnCollisionEnter(Collision collision)
    {
        // Check if the object hitting us contains the word "Shell"
        if (collision.gameObject.name.Contains("Shell"))
        {
            // Destroy the bullet shell so it doesn't hit multiple times
            Destroy(collision.gameObject);

            // Subtract 20 health points per hit
            TakeDamage(20f);
        }
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        Debug.Log(gameObject.name + " took damage! Current Health: " + currentHealth);

        // If health drops to zero, destroy the object
        if (currentHealth <= 0)
        {
            Explode();
        }
    }

    void Explode()
    {
        Debug.Log(gameObject.name + " has exploded and was destroyed!");

        // Remove the tank from the game scene completely
        Destroy(gameObject);
    }
}
