using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eventTrigger : MonoBehaviour {
	private Transform tr;
    private nodeEntity ne;
    private Rigidbody item;

    void Start () {
    	tr = GetComponent<Transform>();
        ne = GetComponent<nodeEntity>();
    }

    void Update () {
        touch();
    }

	void touch () {
		Debug.DrawRay(tr.position, tr.forward * 2.0f, Color.green);
        RaycastHit hit;

		if (Physics.Raycast (tr.position, tr.forward, out hit, 2.0f)) {
			Debug.Log ("Touch:" + hit.collider.gameObject.name + "\n tag:" + hit.collider.tag);
            GameObject gameObj = hit.collider.gameObject;
            node obj = (node)gameObj.GetComponent<node>();

            if (obj != null) {
            	obj.isChecked = true;
                Debug.Log(obj.objName);
                if (Input.GetKeyDown("t")) {
                    obj.setRed();
                    Debug.Log("keycode T");
                    item = gameObj.GetComponent<Rigidbody>();
                    item.GetComponent<MeshRenderer>().material.color = Color.red;
                    // item = gameObj;
                    // gameObj.SetActive(false);
                    // Destroy(gameObj);
                }
            }
		}
	}

	public node getItem (node item) {
		nodeEntity tmp = nodeEntity.FillData(item);
		return item;
	}
}