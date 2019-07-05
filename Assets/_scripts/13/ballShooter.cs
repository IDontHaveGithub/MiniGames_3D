using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballShooter : MonoBehaviour {

    Rigidbody ball;
    float z;
    Vector3 beginPositie;
    

	// Use this for initialization
	void Start () {
        ball = GetComponent<Rigidbody>();
        beginPositie = ball.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            z = Random.Range(-1000f, 1000f);
            ball.AddForce(-2000, 0, z);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ball.transform.position = beginPositie;
            ball.velocity = Vector3.zero;
            ball.freezeRotation = true;
            ball.freezeRotation = false;

        }
		
	}
}
