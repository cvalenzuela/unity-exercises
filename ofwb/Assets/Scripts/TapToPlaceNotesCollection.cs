using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapToPlaceNotesCollection : MonoBehaviour {

	bool placing = false;

	// Called by GazeGestureManager (or RecreateGaze) when the user performs a Select gesture
	void OnSelect(){
		//On each Select gesture, toggle wheter the user is in placing mode.
		placing = !placing;

		// if the user is in placing mode, display the spatial mapping mesh.
		if (placing) {
			SpatialMapping.Instance.DrawVisualMeshes = true;
		} 
		// If the user is not in placing mode, hide the spatial mapping mesh.
		else {
			SpatialMapping.Instance.DrawVisualMeshes = false;
		}
	}
	
	// Update is called once per frame
	void Update () {
		// If the user is in placing mode, update the placement to match the user's gaze
		if (placing) {
			// Do a raycast into the world that will only hit the Spatial Mapping Mesh
			var headPosition = Camera.main.transform.position;
			var gazeDirection = Camera.main.transform.forward;

			RaycastHit hitInfo;
			if (Physics.Raycast (headPosition, gazeDirection, out hitInfo, 30.0f, SpatialMapping.PhysicsRaycastMask)) {
				// Move this objectct object to where the raycast hit the Spatial Mapping mesh
				this.transform.position = hitInfo.point;

				// Rotate this object's parent object to face the user.
				Quaternion toQuat = Camera.main.transform.localRotation;
				toQuat.x = 0;
				toQuat.z = 0;
				this.transform.rotation = toQuat;
			}
		}
	}
}
