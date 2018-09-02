using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arena : MonoBehaviour {

	public float spawnTime;
	private float spawnCount;

	public GameObject spawnBL;
	public GameObject spawnTR;

	public GameObject enemyPrefab;

	// Use this for initialization
	void Start () {
		this.spawnCount = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
		this.spawnCount += Time.deltaTime;

		if(this.spawnCount > this.spawnTime) {
			this.spawnCount = 0.0f;
			float x = Random.Range(spawnBL.transform.position.x, spawnTR.transform.position.x);
			float y = Random.Range(spawnBL.transform.position.y, spawnTR.transform.position.y);
			var enemy = Instantiate(this.enemyPrefab);
			enemy.transform.position = new Vector3(x, y, 0.0f);
		}
	}
}
