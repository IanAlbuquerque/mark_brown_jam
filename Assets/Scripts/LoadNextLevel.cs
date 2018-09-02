using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNextLevel : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D other)
    {
       if(other.gameObject.tag == "hero")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            Debug.Log("Tocou");
        }
    }
}
