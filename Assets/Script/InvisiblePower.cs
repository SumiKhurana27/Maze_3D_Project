using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisiblePower : MonoBehaviour
{

    // Declare a Variable 
    public GameObject player;
    public float invisiblityDuration = 5.0f;
    public EnemyAI_Controller enemyAI;

    private AudioSource audioSource;
    
    [SerializeField] AudioClip collisionSound;

    private Collider enemyCollider;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        enemyCollider = GetComponent<Collider>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Invisible the player if collided with special power 
        if (collision.collider.CompareTag("Player")) 
        {
            StartCoroutine(ApplySpecialPower());

            // Play collision sound
            if (audioSource != null && collisionSound != null)
            {
                // Ensure that the AudioSource component is enabled before playing the sound
                if (!audioSource.enabled)
                {
                    audioSource.enabled = true;
                }

                audioSource.PlayOneShot(collisionSound);
            }
        }
    }
    IEnumerator ApplySpecialPower() 
    {
        // Make a player invisiable   
        SetPlayerInVisibility(true);
        // Stop enemy Detection 
        enemyAI.StopDetection();
        // Disible the enemy collider 
        DisableEnemyCollider(true);


        // Also Destroy the game object 
        Destroy(gameObject);

        // Wait for the time to visiable
        yield return new WaitForSeconds(invisiblityDuration);

        // Restore player visibility
        SetPlayerInVisibility(false);
        // Resume the player detection and their animations
        enemyAI.ResumeDetection();
        enemyAI.ResumeAnimations();
        // Enable enemy collider 
        DisableEnemyCollider(false);    

    }

    void SetPlayerInVisibility(bool isVisible) 
    {
        Renderer[] renderers = player.GetComponentsInChildren<Renderer>();
        foreach (Renderer renderer in renderers) 
        {
            renderer.enabled = !isVisible;
        }
    }

    void DisableEnemyCollider(bool disable) 
    {
        if (enemyCollider != null) 
        {
            enemyCollider.enabled = !disable;
        }

    }
}
