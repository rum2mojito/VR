using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballTrigger : MonoBehaviour {
	private Transform trigger;
	private bool checkedFlag = false;

	public Material originMat;
	public Material TransMat;
	public int Id;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnTriggerEnter (Collider col) {
		Debug.Log("ball in");
		if (col.gameObject.tag == "Ball") {
			GameObject gameObj = col.gameObject;
			ball obj = (ball)gameObj.GetComponent<ball>();
			Debug.Log("ball ID: " + obj.getId());
			if (obj != null) {
				Debug.Log("ball ID: " + obj.getId());
				if (obj.getId() != Id) {
					Rigidbody item = gameObj.GetComponent<Rigidbody>();
					item.GetComponent<Rigidbody>().isKinematic = false;
	                transform.DetachChildren();
	                Vector3 camDirct = transform.TransformDirection(0, 0, 0);
	                // Random ran_x = new UnityEngine.Random();
	                // Random ran_y = new Random();
	                // Random ran_z = new Random();
	                item.velocity =  new Vector3(UnityEngine.Random.Range(-10, 10), UnityEngine.Random.Range(5, 10), UnityEngine.Random.Range(-10, 10));
				}
			}
		}
	}

	private void OnTriggerExist (Collider col) {
		Debug.Log("ball out");
	}

	// void OnTriggerEnter (Collider col)
 //    {
 //        // Debug.Log("enter");
 //        if (col.gameObject.tag == "node" && !success)
 //        {
 //            GameObject gameObj = col.gameObject;
 //            node obj = (node)gameObj.GetComponent<node>();
 //             if (obj != null)
 //            {
 //                obj.isChecked = true;
 //                // Debug.Log(obj.objName);
 //                if (touched.Contains(obj))
 //                {
 //                    // Debug.Log("Contained");
 //                }
 //                else
 //                {
 //                    if (touched.Count >= 1)
 //                    {
 //                        // Debug.Log("Lineeee");
 //                        obj.make(last, gameObj, transMat);
 //                    }
 //                    last = gameObj;
 //                    touched.Add(obj);
 //                    touchedRigid.Add(gameObj);
 //                    gameObj.GetComponent<MeshRenderer>().material = transMat;
 //                    item = gameObj.GetComponent<Rigidbody>();
 //                    // item.GetComponent<MeshRenderer>().material = transMat;
 //                }
 //            }
 //        }
 //    }
}
