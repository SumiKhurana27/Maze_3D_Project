using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Health : MonoBehaviour
{
    // Declare a Variable
    public int playerHealth = 100;

    public void TakeDamage(int damage) 
    {
        // Ensure the damage to the player 
        playerHealth -= damage;
        if (playerHealth <= 0) 
        {
            Die();
        }
    }
    void Die() 
    {
        // Make sure that player get died 
        Debug.Log("Player Died!");
        // Reload the current scene
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }
}
