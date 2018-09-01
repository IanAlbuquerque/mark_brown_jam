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

	// Use this for initialization
	void Start () {
		this.bulletRigidBody = this.GetComponent<Rigidbody2D>();
		this.lifetimeCounter = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
		this.lifetimeCounter += Time.deltaTime;

    Vector3 tempVect = movementDirection.normalized * this.movementSpeed * Time.deltaTime;
    this.bulletRigidBody.MovePosition(this.bulletRigidBody.transform.position + tempVect);

		if(this.lifetimeCounter > this.bulletLifetime) {
			Destroy(this.gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		if(other.gameObject.tag == this.enemyTag) {
			Destroy(other.gameObject);
			Destroy(this.gameObject);
		}
		else if(other.gameObject.tag == this.wallTag) {
			Destroy(this.gameObject);
		}
        else if(other.gameObject.tag == this.heroTag) { 
            SceneManager.LoadScene("GameOver");
            
        }
	}
}
