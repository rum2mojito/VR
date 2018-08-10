using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class treectrl : MonoBehaviour {
	public int treeHealth = 5;
	public GameObject logs;
	public Rigidbody tree;
	private float speed = 8f;

	// Use this for initialization
	void Start () {
		tree.isKinematic = true;
	}
	
	// Update is called once per frame
	void Update () {
		if(treeHealth <= 0)
		{
			tree.isKinematic = false;
			tree.AddForce(transform.forward * speed);
			Wait();
		}
	}


	IEnumerator Wait() {
		Debug.Log("Before Waiting 2 seconds");
		yield return new WaitForSeconds(7);
		Debug.Log("After Waiting 2 Seconds");
		DestroyTree();
	}

	void DestroyTree()
	{
		Destroy(tree);
		
		Vector3 position = new Vector3(0, 0, 0);
		Instantiate(logs, new Vector3(2 * 2.0F, 0, 0), Quaternion.identity);
		Instantiate(logs, tree.transform.position + new Vector3(0,0,0) + position, tree.transform.rotation);
		Instantiate(logs, tree.transform.position + new Vector3(2,2,0) + position, tree.transform.rotation);
		Instantiate(logs, tree.transform.position + new Vector3(5,5,0) + position, tree.transform.rotation);
		
	}
}
