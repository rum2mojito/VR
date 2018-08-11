using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class node : MonoBehaviour {

    public int objId;
    public string objName;
    public string note;

    public bool isChecked;

    private bool flag = true;
    private LineRenderer line;

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

    public int getID() {
        return objId;
    }

    public void make (GameObject target1, GameObject target2, Material mat) {
        
        line = this.gameObject.AddComponent<LineRenderer>();
        line.material = mat;
        // Transform tmp = Instantiate(prefab);
        line.SetVertexCount(2);
        // line.SetColors(Color.yellow, Color.red);
        line.SetWidth(0.5f, 0.5f);

        line.SetPosition(0, target1.GetComponent<Transform>().position);
        line.SetPosition(1, target2.GetComponent<Transform>().position);
    }

    public void deleteLine () {
        Debug.Log("Delete");
        Destroy(line);
    }
}
