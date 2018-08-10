using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class info : MonoBehaviour {
	private GUISkin menuSkin;
	private int fwd = 0;
	private int back = 1;
	private int right = 2;
	private int left = 3;

	private bool showGUI = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown("i"))
		{
			showGUI = !showGUI;
		}
		
		if(showGUI == true)
		{
			Time.timeScale = 0;
		}
		
		if(showGUI == false)
		{
			Time.timeScale = 1;
		}

		OnGUI();
	}

	void OnGUI() {
		if(showGUI == true) {
			GUI.skin = menuSkin;
				GUI.BeginGroup(new Rect(Screen.width / 2 - 150, Screen.height / 2 - 150, Screen.width, Screen.height));
					GUI.Box(new Rect(0, 0, 300, 300), "Info");
					
					//Resources collected
					GUI.Label(new Rect(10, 50, 50, 50), "Forward");
					GUI.Box(new Rect(60, 50, 20, 20), "" + "W");
					
					GUI.Label(new Rect(90, 50, 50, 50), "Back");
					GUI.Box(new Rect(130, 50, 20, 20), "" + "S");
					
					GUI.Label(new Rect(170, 50, 50, 50), "Right");
					GUI.Box(new Rect(200, 50, 20, 20), "" + "D");

					GUI.Label(new Rect(10, 130, 50, 50), "Left");
					GUI.Box(new Rect(60, 130, 20, 20), "" + "A");

					GUI.EndGroup();
		}
	}
}
