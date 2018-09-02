using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScorePlayGameScript : MonoBehaviour {

	public Text scoreText;
	public GameObject sunglasses;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		GameObject[] enemies = GameObject.FindGameObjectsWithTag("enemy");		
		if(enemies.Length > 0 ) {
			this.scoreText.text = enemies.Length.ToString() + " left";
			this.sunglasses.SetActive(false);			
		} else {
			this.scoreText.text = "Done";
			this.sunglasses.SetActive(true);
		}
	}
}
