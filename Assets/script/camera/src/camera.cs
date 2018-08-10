using System;
using UnityEngine;
using System.Collections;

public class camera : MonoBehaviour {
	public Transform target;
	private Vector3 offset;

	void Start() {
		offset = target.position - this.transform.position;
	}

	void Update() {
		this.transform.position = target.position - offset;
	}
}
