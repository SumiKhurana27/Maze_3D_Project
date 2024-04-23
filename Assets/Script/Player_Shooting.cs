using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Shooting : MonoBehaviour
{
    // Declare a variable 
    [SerializeField] GameObject fireBallPrefab;
    [SerializeField] float firingSpeed = 5f;

    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        // Fire from left mouse button
        if (Input.GetMouseButtonDown(0)) 
        {
            ShootFireBall();
        }
    }
    
    void ShootFireBall() 
    {
        // Intantaite fireball from player position 
        GameObject fireBall = Instantiate(fireBallPrefab, transform.position, Quaternion.identity);

        // Call the Rigidbody Component
        rb = fireBall.GetComponent<Rigidbody>();

        if (rb != null)
        {
            // Add force in the direction of player facing
            rb.AddForce(transform.forward * firingSpeed , ForceMode.Impulse);
        }
    }
}
