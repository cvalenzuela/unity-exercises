using UnityEngine;
using System.Collections;

// For development without Hololens using the mouse as raycast instead of gaze

public class RecreateInteraction : MonoBehaviour {

	// Represents the hologram that is currently being gazed at.
	public GameObject FocusedObject { get; private set; }

	// Load camera class
	public Camera camera;


	void Start(){	

	}

    void Update() {

    	if (Input.GetMouseButtonDown(0)){
					
			Ray ray = camera.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast(ray, out hit)){
				// If the mouse hits a hologram, use that as the focused object.
				Debug.Log(hit.collider.gameObject); 
				FocusedObject = hit.collider.gameObject;
				FocusedObject.SendMessageUpwards("OnSelect");
			} else {
			// If the raycast did not hit a hologram, clear the focused object.
			FocusedObject = null;
			}
		}

	

    }
}