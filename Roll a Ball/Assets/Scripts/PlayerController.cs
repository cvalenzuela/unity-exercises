using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float speed;

	private Rigidbody rb; // variable to store the reference of the rigidbody object.

	// Start runs only at the beggining. In the first frame.
	void Start () {
		rb = GetComponent<Rigidbody> (); // attach the object's Rigidbody property to the variable rd
	}


	// FixedUpdate runs every frame. Just like update but when physics are involved
	void FixedUpdate ()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		rb.AddForce (movement * speed);
	}
}
