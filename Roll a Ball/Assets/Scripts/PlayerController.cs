using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	public float speed;
	public Text countText;
	public Text winText;

	private Rigidbody rb; // variable to store the reference of the rigidbody object.
	private int count;

	// Start runs only at the beggining. In the first frame.
	void Start () {
		rb = GetComponent<Rigidbody> (); // attach the object's Rigidbody property to the variable rd
		count = 0;
		SetCountText ();
		winText.text = "";
	}


	// FixedUpdate runs every frame. Just like update but when physics are involved
	void FixedUpdate ()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		rb.AddForce (movement * speed);
	}

	void OnTriggerEnter(Collider other) {
		if(other.gameObject.CompareTag("Pick Up")){
			other.gameObject.SetActive(false);
			count = count + 1;
			SetCountText ();
		}
	}

	void SetCountText () {
		countText.text = "Count: " + count.ToString ();
		if (count >= 12) {
			winText.text = "You Win!";
		}
	}
		
}
