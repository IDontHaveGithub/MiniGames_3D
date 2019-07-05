using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotationEyes : MonoBehaviour {

    Transform eye;
	// Use this for initialization
	void Start () {
       eye = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
        var round = 10;
        eye.transform.Rotate(0, 0, round * Time.deltaTime * 6);
    }
}
