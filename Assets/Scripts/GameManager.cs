using UnityEngine;
using TMPro; // Handles your TextMeshPro asset tracking variables

public class GameManager : MonoBehaviour
{
    [Header("UI Reference")]
    public TextMeshProUGUI endGameText;  // Link your EndGameText object here

    [Header("Tank References")]
    public GameObject playerTank;        // Link your green Tank here
    public GameObject enemyTank;         // Link your EnemyTank here

    private bool gameHasEnded = false;   // Cooldown flag to prevent screen flickering

    void Start()
    {
        // Make sure the victory/gameover message is hidden when the game first starts
        if (endGameText != null)
        {
            endGameText.text = "";
        }
    }

    void Update()
    {
        // If someone already won, stop checking everything else
        if (gameHasEnded) return;

        // 1. Check if the Enemy Tank was blown up and deleted from the hierarchy
        if (enemyTank == null && playerTank != null)
        {
            WinGame();
        }
        // 2. Check if the Player Tank was blown up and deleted from the hierarchy
        else if (playerTank == null)
        {
            LoseGame();
        }
    }

    void WinGame()
    {
        gameHasEnded = true;
        if (endGameText != null)
        {
            endGameText.text = "YOU WIN!";
            endGameText.color = Color.yellow; // Make victory stand out in bright yellow
        }
        Debug.Log("Match Result: Player won the round!");
    }

    void LoseGame()
    {
        gameHasEnded = true;
        if (endGameText != null)
        {
            endGameText.text = "GAME OVER";
            endGameText.color = Color.red; // Make defeat clear in deep red
        }
        Debug.Log("Match Result: Enemy tracking AI defeated the player.");
    }
}
