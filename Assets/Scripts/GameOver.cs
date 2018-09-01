using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {
	
    public void RestartGame()
    {
        SceneManager.LoadScene("lv1");
        Debug.Log("Load level");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
	
}
