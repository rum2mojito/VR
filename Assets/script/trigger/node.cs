using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class node : MonoBehaviour {

    public string objId;
    public string objName;
    public string note;

    public bool isChecked;

    private bool flag = true;

    // Use this for initialization
    void Start () {
        isChecked = false;
    }

	// Update is called once per frame
	void Update () {
		if (flag) {
	        if (isChecked) {
	            GetComponent<MeshRenderer>().material.color = Color.green;
	        }
	        isChecked = false;
	    }
    }

    public void setRed () {
    	GetComponent<MeshRenderer>().material.color = Color.red;
    	flag = false;
    }
}
