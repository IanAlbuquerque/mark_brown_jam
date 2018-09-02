using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartMenuScripts1 : MonoBehaviour {

	public Button newGameButton;
	public Button quitButton;


	// Use this for initialization
	void Start () {
		this.newGameButton.onClick.AddListener(this.onClickNewGame);
		this.quitButton.onClick.AddListener(this.onClickQuit);
	}

	public void onClickNewGame() {
		SceneManager.LoadScene("MenuScene");
	}

	public void onClickQuit() {
		Application.Quit();
	}

}
