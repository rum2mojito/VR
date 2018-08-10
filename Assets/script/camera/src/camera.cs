using System;
using UnityEngine;
using System.Collections;

public class camera : MonoBehaviour {
	public Transform target;
	public float speed = 2;
	
	private Vector3 offset = new Vector3(0, 0, 0);
	private Vector3 pos;

	void Start() {
		target = GameObject.FindGameObjectWithTag("Player").transform;
	}

	void Update() {
		pos = target.position + offset;
        this.transform.position = Vector3.Lerp(this.transform.position, pos, speed*Time.deltaTime);
        Quaternion angel = Quaternion.LookRotation(target.position - this.transform.position);
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, angel, speed * Time.deltaTime);
	}
}
