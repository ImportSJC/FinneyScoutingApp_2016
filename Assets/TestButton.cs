using UnityEngine;
using System.Collections;

public class TestButton : MonoBehaviour {

    private bool pressed = false;
    private string buttonText = "test";

	// Use this for initialization
	void Start () {
	
	}

    void OnGUI()
    {
        if (pressed)
        {
            buttonText = "pressed";
        }else
        {
            buttonText = "test";
        }

        if (GUI.Button(new Rect(25, 25, 100, 50), buttonText))
        {
            pressed = !pressed;
        }
    }
	
	// Update is called once per frame
	void Update () {
	    
	}
}
