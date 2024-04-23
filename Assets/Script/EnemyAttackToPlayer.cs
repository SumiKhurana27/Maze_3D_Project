using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // Declare a Variable
    public Animator animator;
    public int attackDamage = 10;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            Debug.Log("Collision");
            // Trigger attacking animation
            animator.SetTrigger("Attack");
            Debug.Log("Attack animation triggered");
            Player_Health playerHealth = collision.collider.GetComponent<Player_Health>();
            if (playerHealth != null)
            {
                // Reduce player's health
                playerHealth.TakeDamage(attackDamage); 
            }
        }
    }
}
