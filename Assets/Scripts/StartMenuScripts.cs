using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartMenuScripts : MonoBehaviour {

	public Button newGameButton;
	public Button creditsButton;
	public Button quitButton;
	public Button backCreditsButton;
	public GameObject mainMenuPanel;
	public GameObject creditsPanel;

	public string firstSceneName;

	// Use this for initialization
	void Start () {
		this.newGameButton.onClick.AddListener(this.onClickNewGame);
		this.creditsButton.onClick.AddListener(this.onClickCredits);
		this.quitButton.onClick.AddListener(this.onClickQuit);
		this.backCreditsButton.onClick.AddListener(this.onClickCreditsBack);
	}

	public void onClickNewGame() {
		SceneManager.LoadScene(this.firstSceneName);
	}

	public void onClickCredits() {
		this.mainMenuPanel.SetActive(false);
		this.creditsPanel.SetActive(true);
	}

	public void onClickQuit() {
		Application.Quit();
	}

	public void onClickCreditsBack() {
		this.mainMenuPanel.SetActive(true);
		this.creditsPanel.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
