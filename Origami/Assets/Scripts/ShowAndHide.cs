using UnityEngine;

public class ShowAndHide : MonoBehaviour {

    public float speed = 1.0F; 
	public Vector3 endMarker = new Vector3(0,0,0);
	private bool start = false;

	// Use this for initialization
	void Start() {

	}

	// Called by when the object is selected
	void OnSelect()	{

		// Transform it's position
       start = true;

	}

	void Update(){
		if(start && transform.position != endMarker){
			transform.position = Vector3.Lerp(transform.position, endMarker, speed * Time.deltaTime);
		}
	}

	// // Called by SpeechManager when the user says the "Reset world" command
	// void OnReset() {
	// 	// If the sphere has a Rigidbody component, remove it to disable physics.
	// 	var rigidbody = this.GetComponent<Rigidbody>();
	// 	if (rigidbody != null) {
	// 		DestroyImmediate(rigidbody);
	// 	}

	// 	// Put the sphere back into its original local position.
	// 	this.transform.localPosition = originalPosition;
	// }

	// // Called by SpeechManager when the user says the "Drop sphere" command
	// void OnDrop(){
	// 	// Just do the same logic as a Select gesture.
	// 	OnSelect();
	// }
}