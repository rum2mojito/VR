using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eventTrigger : MonoBehaviour {
    private GameObject last;
    private Transform tr;
    private nodeEntity ne;
    private Rigidbody item;
    private List<node> touched = new List<node>();
    private List<GameObject> touchedRigid = new List<GameObject>();
    private List<Transform> lights = new List<Transform>();
    private List<int> answer = new List<int> { 1, 2, 3, 4 };
    private bool success = false;

    public int max = 4;
    public Material transMat;
    public Material originMat;
    public Transform light1;
    public Transform light2;
    public Transform light3;
    public Transform light4;
    public Transform light5;

    void Start () {
        tr = GetComponent<Transform>();
        ne = GetComponent<nodeEntity>();
        
    }

    void Awake() {
        // touched = new List<node>();
        lights.Add(light1);
        lights.Add(light2);
        lights.Add(light3);
        lights.Add(light4);
        lights.Add(light5);
    }

    void Update () {
        if (touched.Count >= max) {
            Debug.Log("List full");
            if (checkAnswer()) {
                Debug.Log("Good");
            }
            else
                release();
        }
        else {
            // touch();
        }
        Debug.Log("List: " + touched.Count);
    }

    void touch () {
        // Debug.DrawRay(tr.position, tr.forward * 2.0f, Color.green);
        RaycastHit hit;

        if (Physics.Raycast (tr.position, tr.forward, out hit, 2.0f)) {
            // Debug.Log ("Touch:" + hit.collider.gameObject.name + "\n tag:" + hit.collider.tag);
            GameObject gameObj = hit.collider.gameObject;
            node obj = (node)gameObj.GetComponent<node>();

            if (obj != null) {
                obj.isChecked = true;
                // Debug.Log(obj.objName);
                if (Input.GetKeyDown("t")) {
                    // obj.setRed();
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
                        touchedRigid.Add(gameObj);
                        gameObj.GetComponent<MeshRenderer>().material = transMat;
                        item = gameObj.GetComponent<Rigidbody>();
                        // item.GetComponent<MeshRenderer>().material = transMat;
                    }
                }
            }
        }
        Debug.Log("List: " + touched.Count);
    }

    public void release () {
        for (int i = 0; i < 4; i++)
        {
            touched[i].deleteLine();
            touchedRigid[i].GetComponent<MeshRenderer>().material = originMat;
        }
        touchedRigid = new List<GameObject>();
        touched = new List<node>();
        Debug.Log("release");
    }

    public void release2()
    {
        List<GameObject> tmpRL = new List<GameObject>();
        List<node> tmpNL = new List<node>();
        touchedRigid = tmpRL;
        touched = tmpNL;
        Debug.Log("release");
    }

    bool checkAnswer () {
        
        if (touched.Count == 4) {
            if (touched[0].getID() == answer[0]) {
                for (int i=0; i<4; i++) {
                    if (touched[i].getID() != answer[i]) {
                        return false;
                    }
                }
            }
            else {
                // Debug.Log("checkAnswer");
                for (int i=3, j=0; i>=0; i--, j++) {
                    if (touched[i].getID() != answer[j]) {
                        return false;
                    }
                }
            }
            // release();
            success = true;
            lightUp();
            return true;
        }
        return false;
    }

    public node getItem (node item) {
        nodeEntity tmp = nodeEntity.FillData(item);
        return item;
    }

    void OnTriggerEnter (Collider col)
    {
        // Debug.Log("enter");
        if (col.gameObject.tag == "node" && !success)
        {
            GameObject gameObj = col.gameObject;
            node obj = (node)gameObj.GetComponent<node>();

            if (obj != null)
            {
                obj.isChecked = true;
                // Debug.Log(obj.objName);
                if (touched.Contains(obj))
                {
                    // Debug.Log("Contained");
                }
                else
                {
                    if (touched.Count >= 1)
                    {
                        // Debug.Log("Lineeee");
                        obj.make(last, gameObj, transMat);
                    }
                    last = gameObj;
                    touched.Add(obj);
                    touchedRigid.Add(gameObj);
                    gameObj.GetComponent<MeshRenderer>().material = transMat;
                    item = gameObj.GetComponent<Rigidbody>();
                    // item.GetComponent<MeshRenderer>().material = transMat;
                }
            }
        }
    }

    void OnTriggerExit(Collider col)
    {
        // Debug.Log("out");
    }

    void lightUp ()
    {
        for (int i = 0; i < 5; i ++)
        {
            // Debug.Log("lightUp up: " + i);
            Light light = lights[i].GetComponent<Light>();
            light.range = 100;
        }
    }

    public bool getStatus ()
    {
        return success;
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
