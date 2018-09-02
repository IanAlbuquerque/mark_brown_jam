using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BulletMovement : MonoBehaviour {

	public Vector3 movementDirection;
  public float movementSpeed;


  private Rigidbody2D bulletRigidBody;

	public float bulletLifetime;
	private float lifetimeCounter;

	public string bulletTag;
	public string enemyTag;
	public string heroTag;
	public string wallTag;
	public string scriptsTag;

	public GameObject explosionPrefab;

	// Use this for initialization
	void Start () {
		this.bulletRigidBody = this.GetComponent<Rigidbody2D>();
		this.lifetimeCounter = 0.0f;

		float angle = Mathf.Atan2(movementDirection.y, movementDirection.x) * Mathf.Rad2Deg;
		this.bulletRigidBody.MoveRotation(angle);// = Quaternion.AngleAxis(angle, Vector3.forward);
	}
	
	// Update is called once per frame
	void Update () {
		float angle = Mathf.Atan2(movementDirection.y, movementDirection.x) * Mathf.Rad2Deg;
		this.bulletRigidBody.MoveRotation(angle);// = Quaternion.AngleAxis(angle, Vector3.forward);

		this.lifetimeCounter += Time.deltaTime;

    Vector3 tempVect = movementDirection.normalized * this.movementSpeed * Time.deltaTime;
    this.bulletRigidBody.MovePosition(this.bulletRigidBody.transform.position + tempVect);

		if(this.lifetimeCounter > this.bulletLifetime) {
			Destroy(this.gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		if(other.gameObject.tag == this.enemyTag) {
			var explosion = Instantiate(this.explosionPrefab);
			explosion.transform.position = other.gameObject.transform.position;
			Destroy(other.gameObject);
			Destroy(this.gameObject);
		}
		else if(other.gameObject.tag == this.wallTag) {
			Destroy(this.gameObject);
		}
		else if(other.gameObject.tag == this.heroTag) { 
			GameObject[] scripts = GameObject.FindGameObjectsWithTag(this.scriptsTag);
			if(!scripts[0].GetComponent<PlayerMovement>().isPlayerInvulnerable) {
				Scene scene = SceneManager.GetActiveScene();
				SceneManager.LoadScene(scene.name);
			}
		}
	}
}
