using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAITeste : MonoBehaviour {

	public string enemyTag;
	public string heroTag;
    public bool FollowEnter=false;
	public bool FireEnter=false;
	public bool StopEnter = false;
    public float moveSpeed;
	public GameObject bulletSpawnerPoint;


	//public float detectDist;

	public float shootDuration;
	public GameObject bulletPrefab;
	private float shootCount;

	private GameObject hero;
	private Rigidbody2D thisEnemyRigidBody;

	// Use this for initialization
	void Start () {
		this.shootCount = 0;
		GameObject[] heroes = GameObject.FindGameObjectsWithTag(this.heroTag);
		this.hero = heroes[0];
		this.thisEnemyRigidBody = this.GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void Update () {
		// Find enemies in scene
		this.shootCount += Time.deltaTime;

		Debug.Log(this.StopEnter);
        if (this.FollowEnter)
        {
			var deltaPlayer = this.hero.transform.position - this.transform.position;
            Debug.Log("Pursuit");
            Vector3 tempVect = deltaPlayer.normalized * this.moveSpeed * Time.deltaTime;
			float angle = Mathf.Atan2(deltaPlayer.y, deltaPlayer.x) * Mathf.Rad2Deg;
			this.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
			if(!this.StopEnter) {
            	this.thisEnemyRigidBody.MovePosition(this.transform.position + tempVect);
			}
        }

        if (this.FireEnter && this.shootCount > this.shootDuration)
        {
			var deltaPlayer = this.hero.transform.position - this.transform.position;
			var bullet = Instantiate(this.bulletPrefab);
			bullet.transform.position = this.bulletSpawnerPoint.transform.position;
			BulletMovement bulletMovementScript = bullet.GetComponent<BulletMovement>();
			bulletMovementScript.movementDirection = deltaPlayer;
        }
        //RangeFollow.collider.

//        GetComponentInParent<ScriptPai>().var = true;


		/*foreach(GameObject enemy in enemies) {
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
		}*/

		if(this.shootCount > this.shootDuration) {
			this.shootCount = 0.0f;
		}
	}
}
