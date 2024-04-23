using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{

    // Declare a variable 
    [SerializeField] float delayTime = 2f;
    private void OnCollisionEnter(Collision collision)
    {
        // When collided finish collider
        if (collision.collider.CompareTag("Finish")) 
        {
            // Restart the level after 2 second

            Invoke("Maze3D", delayTime);
        }
    }
    void LoadScene() 
    {
        // Load a scene 
        SceneManager.LoadScene("Maze3D");
    }

}
