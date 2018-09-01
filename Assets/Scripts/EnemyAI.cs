using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {

	public string enemyTag;
	public GameObject hero;

	public float detectDist;
	public float bulletSpawnRadius;

	public float shootDuration;
	public GameObject bulletPrefab;
	private float shootCount;
	// Use this for initialization
	void Start () {
		this.shootCount = 0;
	}

	// Update is called once per frame
	void Update () {
		// Find enemies in scene
		this.shootCount += Time.deltaTime;

		GameObject[] enemies = GameObject.FindGameObjectsWithTag(this.enemyTag);

		foreach(GameObject enemy in enemies) {
			var deltaPlayer = this.hero.transform.position - enemy.transform.position;
			var deltaPlayerDist = deltaPlayer.magnitude;
			// Turn to player
			if(deltaPlayerDist < detectDist) {
				float angle = Mathf.Atan2(deltaPlayer.y, deltaPlayer.x) * Mathf.Rad2Deg;
				enemy.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
			}

			// Shoot
			if(	deltaPlayerDist < detectDist &&
					this.shootCount > this.shootDuration) {
				var bullet = Instantiate(this.bulletPrefab);
				bullet.transform.position = enemy.transform.position + deltaPlayer.normalized * this.bulletSpawnRadius;
				BulletMovement bulletMovementScript = bullet.GetComponent<BulletMovement>();
				bulletMovementScript.movementDirection = deltaPlayer;
			}
		}

		if(this.shootCount > this.shootDuration) {
			this.shootCount = 0.0f;
		}
	}
}
