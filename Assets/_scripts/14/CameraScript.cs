using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {

    public Transform Target;
    float afstand = 30f;

	// Use this for initialization
	void Start () {
        Target = GameObject.Find("Player").GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
        if (null != Target)
        {
            Vector3 positie = transform.position;
            positie.z = Target.position.z - afstand;
            positie.x = 0f;
            transform.position = positie;
        }
	}
}
