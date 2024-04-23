using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class EnemyAI_Controller : MonoBehaviour
{
    /// <summary>
    /// AI formation (Enemy)
    /// </summary>

    // Declare a variable 
    [SerializeField] float enemySpeed = 1f;
    [SerializeField] float detectionRange = 2f;
    [SerializeField] float actionRange = 0.5f;

    [SerializeField] Transform player;
    [SerializeField] Animator animator;

    bool isPlayerDetected = true;
    float originalDetectionRange;

    // Start is called before the first frame update
    void Start()
    {
        // Call the animation component 
        animator = GetComponent<Animator>();  
        
        originalDetectionRange = detectionRange;
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayerDetected)
        {

            float distanceToPlayer = Vector3.Distance(transform.position, player.position);
            // Check if the player is in detection range 
            if (distanceToPlayer <= detectionRange)
            {
                // Calculate direction to player while ignoring Y position
                Vector3 directionToPlayer = player.position - transform.position;
                directionToPlayer.y = 0f;
                directionToPlayer.Normalize();

                // Rotate the enemy towards the player 
                transform.rotation = Quaternion.LookRotation(directionToPlayer);
                // Moves towards them 
                transform.Translate(directionToPlayer * enemySpeed * Time.deltaTime, Space.World);
                // Apply walking animation
                animator.SetBool("isWalking", true);

                if (distanceToPlayer <= actionRange)
                {
                    // Aplly the attacking animation in several condition
                    animator.SetBool("isAttacking", true);

                }
                else
                {
                    animator.SetBool("isAttacking", false);
                }
            }

            else
            {
                // Remain idle position 
                animator.SetBool("isWalking", false);
                animator.SetBool("isAttacking", false);
            }
        }
    }

    public void StopDetection() 
    {
        // Stop enemy detection when player collide with special power 
        isPlayerDetected = false;

        animator.SetBool("isWalking", false);
        animator.SetBool("isAttacking", false);
    }
    public void ResumeDetection() 
    {
        // Resume the detection after given time 
        isPlayerDetected = true;

        detectionRange = originalDetectionRange;    
    }

    public void ResumeAnimations()
    {
        // Resume the animation after time will gets over
        animator.SetBool("isWalking", true);
        animator.SetBool("isAttacking", false);
    }
}
