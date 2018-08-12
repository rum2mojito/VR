using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eventTrigger : MonoBehaviour {
    private GameObject last;
    private Transform tr;
    private nodeEntity ne;
    private Rigidbody item;
    private List<node> touched = new List<node>();
    private List<Rigidbody> touchedRigid = new List<Rigidbody>();

    public int max = 4;
    public Material transMat;
    public Material originMat;

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
                        if (touched.Count >= 1) {
                            // Debug.Log("Lineeee");
                            obj.make(last, gameObj, transMat);
                        }
                        last = gameObj;
                        touched.Add(obj);
                        touchedRigid.Add(item);
                        item = gameObj.GetComponent<Rigidbody>();
                        item.GetComponent<MeshRenderer>().material = transMat;
                    }
                }
            }
        }
        Debug.Log("List: " + touched.Count);
    }

    void release () {
        foreach (node item in touched) {
            item.deleteLine();
            touched.Remove(item);
        }

        foreach (Rigidbody item in touchedRigid) {
            item.GetComponent<MeshRenderer>().material = originMat;
            touchedRigid.Remove(item);
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

    // void make (GameObject target1, GameObject target2) {
    //     LineRenderer line;
    //     line = this.gameObject.AddComponent<LineRenderer>();
    //     // Transform tmp = Instantiate(prefab);
    //     line.SetVertexCount(2);
    //     line.SetColors(Color.yellow, Color.red);
    //     line.SetWidth(0.01f, 0.01f);

    //     line.SetPosition(0, target1.GetComponent<Transform>().position);
    //     line.SetPosition(1, target2.GetComponent<Transform>().position);
    // }
}
