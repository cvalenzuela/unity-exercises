/*
Move and/or scale a game object to a desire position and size.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour {

	// Speed of the movement
	public float speed = 1.0F;

	// Origin Position
	public Vector3 originPosition = new Vector3 (0, 0, 2);
	// Target Position
	public Vector3 targetPosition = new Vector3 (-1.18F, 0.55F, 2);

	// Origin Rotation
	public Quaternion originRotation = Quaternion.Euler (0, 0, 0);
	// Target Rotation
	public Quaternion targetRotation = Quaternion.Euler (-1, -0.08F, -0.08F);

	// Origin Scale
	public Vector3 originScale = new Vector3 (0, 0, 0);
	// Target Scale
	public Vector3 targetScale = new Vector3 (0.7F, 0, 0.05F);

	// Boolean to start the movement
	private bool start = false;
	// Boolean to reset the object
	private bool reset = false;

	// Function to be called when the object is selected (gazed at)
	void OnSelect() {
		start = true;
	}

	// Function to be called when the object is reseted (gazed at)
	void OnReset() {
		reset = true;
	}

	void Update () {
		// If start is true and the position and rotation is not the desired one, move and rotate using lerp.
		if(start && transform.position != targetPosition){
			// Move
			transform.position = Vector3.Lerp (transform.position, targetPosition, speed * Time.deltaTime);
			// Rotate
			transform.rotation = Quaternion.Lerp (transform.rotation, targetRotation, speed * Time.deltaTime );
			// Scale
			transform.localScale = Vector3.Lerp (transform.localScale, targetScale, speed * Time.deltaTime);

		}
		// If reset is true and the position and rotation is not the origin one, move and rotate using lerp.
		if(reset && transform.position != originPosition){
			// Move
			transform.position = Vector3.Lerp (transform.position, originPosition, speed * Time.deltaTime);
			// Rotate
			transform.rotation = Quaternion.Lerp (transform.rotation, originRotation, speed * Time.deltaTime );
			// Scale
			transform.localScale = Vector3.Lerp (transform.localScale, originScale, speed * Time.deltaTime);

		}
	}
}
