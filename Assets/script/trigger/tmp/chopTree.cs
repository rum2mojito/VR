using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chopTree : MonoBehaviour {

	public float rayLength = 0f;

	private treectrl treeScript;
	private playerControl playerAnim;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		attack();
	}

	void attack() {
		RaycastHit hit;
		Vector3 fwd = transform.TransformDirection(Vector3.forward);

		if(Physics.Raycast(transform.position, fwd, out hit, rayLength))
		{
			if(hit.collider.gameObject.tag == "Tree")
			{
				Debug.Log("Hit");
				treeScript = GameObject.Find(hit.collider.gameObject.name).GetComponent<treectrl>();
				playerAnim = GameObject.FindWithTag ("Player").GetComponent<playerControl>();
				treeScript.treeHealth -= 1;
			}
		}
	}
}
