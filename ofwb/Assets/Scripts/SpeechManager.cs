/*
Hololens Speech Manager
*/

using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class SpeechManager : MonoBehaviour {

	// Word recognizer
	KeywordRecognizer keywordRecognizer = null;
	Dictionary<string, System.Action> keywords = new Dictionary<string, System.Action>();

	void Start () {
		// Set the keywords to trigger events

		// Clean the scene
		keywords.Add ("Clean", () => {
			// Call the onClean method on every descendant object.
			this.BroadcastMessage ("OnReset");
		});

		// Show More
		keywords.Add ("Show me more", () => {
			// Get the current Gazed object from the Gaze Gesture Manager class
			var focusObject = GazeGestureManager.Instance.FocusedObject;
			// If there's an object
			if (focusObject != null) {
				// Call the onSelect event
				focusObject.SendMessage ("OnSelect");
			}
		});

		// Settings
		keywords.Add ("Settings", () => {
			// Call the onClean method on every descendant object.
			this.BroadcastMessage ("OnSettings");
		});

		// Tell the KeywordRecognizer about our keywords.
		keywordRecognizer = new KeywordRecognizer(keywords.Keys.ToArray());

		// Register a callback for the KeywordRecognizer and start recognizing
		keywordRecognizer.OnPhraseRecognized += KeywordRecognizer_OnPhraseRecognized;
		keywordRecognizer.Start();
	}
	

	private void KeywordRecognizer_OnPhraseRecognized(PhraseRecognizedEventArgs args){
		System.Action keywordAction;
		if (keywords.TryGetValue(args.text, out keywordAction))	{
			keywordAction.Invoke();
		}
	}
}
