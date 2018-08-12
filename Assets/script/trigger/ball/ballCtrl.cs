// G for throwing

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballCtrl : MonoBehaviour {
    private Transform tr;
    private pack pack;
    private Rigidbody item;
    private bool isOnHands = false;

    void Start() {
        tr = GetComponent<Transform>();
        pack = GetComponent<pack>();
    }

    void Update() {
        getPack();
        if (isOnHands) {
            onHands();
        }
        throwing();
    }

    void getPack() {
        Debug.DrawRay(tr.position, tr.forward * 2.0f, Color.green);
        RaycastHit hit;
        if (Physics.Raycast (tr.position, tr.forward, out hit, 2.0f)) {
            // Debug.Log ("Hit:" + hit.collider.gameObject.name + "\n tag:" + hit.collider.tag);
            GameObject gameObj = hit.collider.gameObject;
            ObjItem obj = (ObjItem)gameObj.GetComponent<ObjItem>();
            if (obj != null)
            {
                obj.isChecked = true;
                Debug.Log(obj.objName);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    Debug.Log("keycode E");
                    item = gameObj.GetComponent<Rigidbody>();
                    isOnHands = true;
                }
            }
        }
    }

    void onHands() {
        item.transform.position = this.transform.position + new Vector3(1f,0.5f,1f);
        Debug.Log ("Hit:" + item.name + " tag:" + item.tag);
    }

    void throwing() {
        // Debug.Log("in");
        if (Input.GetKeyDown("g") && isOnHands) {
            if (true) {
                // Debug.Log("Throws");
                item.GetComponent<Rigidbody>().isKinematic = false;
                transform.DetachChildren();
                Vector3 camDirct = transform.TransformDirection(0, 0, 100);
                item.velocity =  new Vector3(0, 0, 10);
                // item.AddForce(camDirct, ForceMode.Force);
                // Debug.Log("Throwing");
            }
            isOnHands = false;
        }
    }
}
