using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eventTrigger : MonoBehaviour {
    private Transform tr;
    private nodeEntity ne;
    private Rigidbody item;
    private List<node> touched = new List<node>();

    public int max = 4;

    void Start () {
        tr = GetComponent<Transform>();
        ne = GetComponent<nodeEntity>();
        
    }

    void Awake() {
        // touched = new List<node>();
    }

    void Update () {
        if (touched.Count >= max) {
            Debug.Log("List full");
            if (checkAnswer()) {
                Debug.Log("Good");
            }
            release();
        }
        else {
            touch();
        }
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
                    if (touched.Contains(obj)) {
                        Debug.Log("Contained");
                    }
                    else {
                        touched.Add(obj);
                        item = gameObj.GetComponent<Rigidbody>();
                        item.GetComponent<MeshRenderer>().material.color = Color.red;
                    }
                }
            }
        }
        Debug.Log("List: " + touched.Count);
    }

    void release () {
        foreach (node item in touched) {
            touched.Remove(item);
        }
    }

    bool checkAnswer () {
        List<int> answer = new List<int>{1, 2, 3, 5};
        if (touched.Count == 4) {
            if (touched[0].getID() == answer[0]) {
                for (int i=0; i<4; i++) {
                    if (touched[i].getID() != answer[i]) {
                        return false;
                    }
                }
            }
            else {
                for (int i=4; i>=0; i--) {
                    if (touched[i].getID() != answer[i]) {
                        return false;
                    }
                }
            }
            // release();
            return true;
        }
        return false;
    }

    public node getItem (node item) {
        nodeEntity tmp = nodeEntity.FillData(item);
        return item;
    }
}