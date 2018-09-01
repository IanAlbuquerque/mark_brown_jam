using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NarrativeControl : MonoBehaviour {

	public Button nextButton;
	public GameObject[] openingObjects;

	public string gameScene;

	private int currentObjIndex;

	// Use this for initialization
	void Start () {
		this.nextButton.onClick.AddListener(this.onClickNext);
	}
	
	void onClickNext() {
		this.openingObjects[this.currentObjIndex].SetActive(false);
		if(this.currentObjIndex + 1 < this.openingObjects.Length) {
			this.currentObjIndex++;
			this.openingObjects[this.currentObjIndex].SetActive(true);
		} else {
			SceneManager.LoadScene(this.gameScene);
		}
	}
}
