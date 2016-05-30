using UnityEngine;
using System.Collections;


public class ToggleFunction : MonoBehaviour {

	InstantGuiToggle myToggle;

	private bool tempBool;

	private int offsetRight = 0;
	private int offsetLeft = 0;
	private int offsetTop = 0;
	private int offsetBottom = 0;

	// Use this for initialization
	void Start () {
		myToggle = this.GetComponent<InstantGuiToggle> ();
		tempBool = myToggle.check;

		offsetRight = myToggle.offset.right;
		offsetLeft = myToggle.offset.left;
		offsetTop = myToggle.offset.top;
		offsetBottom = myToggle.offset.bottom;
	}

	void onToggleClick(){
		Vibration.Vibrate (20);
		if (!myToggle.check) {
			myToggle.check = true;
		}
	}

	// Update is called once per frame
	void Update () {
		myToggle.offset.right = (int)(offsetRight * SharedValues.dpiScale);
		myToggle.offset.left = (int)(offsetLeft * SharedValues.dpiScale);
		myToggle.offset.top = (int)(offsetTop * SharedValues.dpiScale);
		myToggle.offset.bottom = (int)(offsetBottom * SharedValues.dpiScale);
		tempBool = myToggle.check;
//		updateToggles ();
		if (myToggle.activated) {
			onToggleClick ();
		}
	}
}
