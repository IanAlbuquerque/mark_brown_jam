using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public GameObject hero;
	public Rigidbody2D heroRigidBody;
	public float moveSpeed;
	public float dashMultiplier;
	
	// Update is called once per frame
	void FixedUpdate () {
		// Look at mouse position
		var v3 = Input.mousePosition;
		v3.z = 0.0f;
		v3 = Camera.main.ScreenToWorldPoint(v3);
		v3 -= this.hero.transform.position;

		float angle = Mathf.Atan2(v3.y, v3.x) * Mathf.Rad2Deg;
		this.hero.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

		//Dash
		bool hasDashed = false;
		if(Input.GetKeyDown("space"))
		{
			hasDashed = true;
		}

		// Move with wasd
    float h = Input.GetAxisRaw("Horizontal");
    float v = Input.GetAxisRaw("Vertical");
    Vector3 tempVect = new Vector3(h, v, 0);
    tempVect = tempVect.normalized * this.moveSpeed * Time.deltaTime;
		tempVect *= hasDashed?this.dashMultiplier:1.0f;
    this.heroRigidBody.MovePosition(this.heroRigidBody.transform.position + tempVect);
	}
}
