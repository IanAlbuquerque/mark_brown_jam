using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndlessScore : MonoBehaviour {

	public Text scoreText;
	public int totalKilled = 0;

	// Use this for initialization
	void Start () {
		this.totalKilled = 0;
	}
	
	// Update is called once per frame
	void Update () {
		this.scoreText.text = this.totalKilled.ToString() + " killed";
	}
}
