/*
Hololens Gaze Gesture Manager
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine.VR.WSA.Input;
using UnityEngine;

public class GazeGestureManager : MonoBehaviour {

	// Create an instance of this GazeGestureManager class.
	public static GazeGestureManager Instance { get; private set; }

	// The object that the user will be gazing at.
	public GameObject FocusedObject {get; private set; }

	// Hololens Manager class with API for recognizing user gestures.
	GestureRecognizer recognizer;
		
	void Start () {
		Instance = this;
		// Set up a GestureRecognizer instance.
		recognizer = new GestureRecognizer();
		// When a tapped event is trigger, get the object being gazed at.
		recognizer.TappedEvent += (AudioSource, tapCount, Ray) => {
			// Send an OnSelect message to the focused object
			if (FocusedObject != null) {
				FocusedObject.SendMessageUpwards ("OnSelect");
			}
		};
		recognizer.StartCapturingGestures ();	
	}

	void Update () {

		// Figure out which Hologram is focused this current frame.
		GameObject oldFocusObject = FocusedObject;

		//Get user's current head position and gaze direction.
		var headPosition = Camera.main.transform.position;
		var gazeDirection = Camera.main.transform.forward;

		// Create an empty RaycastHit element
		RaycastHit hitInfo;
		// Check if the ray hits an element. If it does, store the hitted element in the hit variable.
		if (Physics.Raycast (headPosition, gazeDirection, out hitInfo)) {
			// Save the object as the FocusedObject
			FocusedObject = hitInfo.collider.gameObject;
		} else {
			// If nothing is hit, clear the FocusedObject
			FocusedObject = null;
		}

		// If the focused object changed, start detecting again
		if (FocusedObject != oldFocusObject) {
			recognizer.CancelGestures ();
			recognizer.StartCapturingGestures ();
		}
		
	}
}
