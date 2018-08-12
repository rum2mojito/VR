using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reset : MonoBehaviour {
    private eventTrigger et;

	// Use this for initialization
	void Start () {
		et = this.GetComponent<eventTrigger>();
    }
	
	// Update is called once per frame
	void Update () {
		if (et.getStatus())
        {
            Debug.Log("wait");
            StartCoroutine(_wait_());
        }
	}

    IEnumerator _wait_()
    {
        yield return new WaitForSeconds(2);
        Reset();

    }

    private void Reset()
    {
        Debug.Log("reset");
        et.release2();
    }
}
