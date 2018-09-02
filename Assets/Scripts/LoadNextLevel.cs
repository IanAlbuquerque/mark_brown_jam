using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNextLevel : MonoBehaviour {

    void OnTriggerEnter2d(Collider2D collision)
    {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            Debug.Log("Tocou");
       /* if(other.gameObject.tag == "hero")
        {
        }*/
    }
}
