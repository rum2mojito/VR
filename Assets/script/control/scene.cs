using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class scene : MonoBehaviour {

	public void gameStart () {
		setColor (255, 215, 0);
	}

	public void setColor (int x, int y, int z) {
		RenderSettings.ambientLight = new Color (x, y, z, 0);
	}
	
	// Update is called once per frame
	public void gameEnd() {
		setColor (225, 225, 225);
		
	}
}
