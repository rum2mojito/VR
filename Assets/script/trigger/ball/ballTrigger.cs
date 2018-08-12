using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballTrigger : MonoBehaviour {
	private Transform trigger;
	private bool checkedFlag = false;

	public Material originMat;
	public Material TransMat;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private OnTriggerEnter (Collider col) {
		Debug.Log("ball in");
	}

	private OnTriggerExist (Collider col) {
		Debug.Log("ball out");
	}
}
