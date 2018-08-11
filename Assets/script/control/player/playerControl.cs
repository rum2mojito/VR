using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControl : MonoBehaviour {
	public float speed = 10f;
	public float rotationSpeed = 100f;

	private Transform tr;
    private pack pack;
    private GameObject item;

    void Start() {
    	tr = GetComponent<Transform>();
        pack = GetComponent<pack>();
        item = new GameObject();
        item.SetActive(false);
    }

	void Update() {
		Control();
		getPack();
        onHands();
	}

	void getPack() {
		if (Input.GetKeyDown("u")) {
            pack.showPack();
        }

        Debug.DrawRay(tr.position, tr.forward * 2.0f, Color.green);
        RaycastHit hit;
        if (Physics.Raycast (tr.position, tr.forward, out hit, 2.0f)) {
            // Debug.Log ("Hit:" + hit.collider.gameObject.name + "\n tag:" + hit.collider.tag);
            GameObject gameObj = hit.collider.gameObject;
            ObjItem obj = (ObjItem)gameObj.GetComponent<ObjItem>();
            // if (Input.GetKeyDown("e"))
            // {
            // 	Debug.Log("Press 'E'");
            // 	item = gameObj;
            //     gameObj.SetActive(false);
            //     Destroy(gameObj);
            //     item.SetActive(true);
            // }
            if (obj != null)
            {
                obj.isChecked = true;
                Debug.Log(obj.objName);
                if (Input.GetKeyDown(KeyCode.E))
                {
                	Debug.Log("E'");
                    item = gameObj;
                    // gameObj.SetActive(false);
                    // Destroy(gameObj);
                }
            }
        }
	}

	void Control() {
        float translation = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime;

        transform.Translate(0, 0, translation);
        transform.Rotate(0, rotation, 0);
	}


    void onHands() {
        item.transform.position = this.transform.position + new Vector3(1f,0.5f,1f);
        Debug.Log ("Hit:" + item.name + " tag:" + item.tag);
    }
}
