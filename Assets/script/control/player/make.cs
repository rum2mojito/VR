using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class make : MonoBehaviour {
	private bool canBuild = true;

	public GameObject player;
	public Transform prefab;


	// Use this for initialization
	void Start () {
		prefab.GetComponent<Renderer>().material.color = Color.green;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown("b") && canBuild == true) {
			Transform point = Instantiate(prefab);
			point.localPosition = player.transform.position + new Vector3(0, 0, 5);
		}
	}

	void OntriggerEnter(Collision col) {
		if(col.gameObject.tag == "Terrain" || col.gameObject.tag == "Tree") {
			prefab.GetComponent<Renderer>().material.color = Color.red;

			canBuild = false;
		}
	}

	void OnTriggerExit(Collision col) {
		if(col.gameObject.tag == "Terrain" || col.gameObject.tag == "Tree") {
			prefab.GetComponent<Renderer>().material.color = Color.green;

			canBuild = true;
		}
	}
}
