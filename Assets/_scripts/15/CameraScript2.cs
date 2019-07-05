using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript2 : MonoBehaviour {

    // for following Player
    public Transform Target;
    Vector3 offset;

    // for fluid motion in Camera
    float damping = 3f;

    
    Quaternion startRot;

	// Use this for initialization
	void Start () {
        Target = GameObject.Find("Player").GetComponent<Transform>();
        offset = Target.position - transform.localPosition;
        startRot = transform.rotation;
    }
	
	// Update is called once per frame
	void Update () {

        

        // simple camera follow script for 3d character from internet.
        float currentAngle = transform.eulerAngles.y;
        float desiredAngle = Target.transform.localEulerAngles.y;
        float angle = Mathf.LerpAngle(currentAngle, desiredAngle, Time.deltaTime * damping);

        Quaternion rotation = Quaternion.Euler(0, angle, 0);
        transform.position = Target.transform.position - (rotation * offset);
        

        transform.LookAt(Target.transform);

        if(Target.position.y <= -4f)
        {
            transform.rotation = startRot;
        }
	}
}
