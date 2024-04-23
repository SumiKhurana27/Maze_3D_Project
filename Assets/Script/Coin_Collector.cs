using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin_Collector : MonoBehaviour
{

    // Declare a variable 
    [SerializeField] private AudioSource coinCollectionAudio;

    // If player collide with Coin 
    private void OnCollisionEnter(Collision collision)
    {
        // Destory the coin if player is collided with them
        if (collision.gameObject.CompareTag("Coin")) 
        {
            Destroy(collision.gameObject);
            coinCollectionAudio.Play();
        }
    }
}
