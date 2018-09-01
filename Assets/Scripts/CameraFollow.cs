using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
    public Transform heroPos;
    private Vector3 offset;

	// Use this for initialization
	void Start () {
    
	}
	
	// Update is called once per frame
	void Update () {
        offset = new Vector3(0, 0, -3.5f);
        transform.position = heroPos.position + offset;
    }
}
