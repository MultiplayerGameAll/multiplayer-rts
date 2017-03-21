using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	
	public float moveSpeed = 0.2f;
	public float moveRotation = 0.05f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(0, 0, Input.GetAxis("Vertical") * moveSpeed);
		transform.Rotate(0, Input.GetAxis("Horizontal") * moveRotation, 0);
	}
}
