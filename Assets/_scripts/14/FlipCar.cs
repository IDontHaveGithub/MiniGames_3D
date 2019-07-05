using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipCar : MonoBehaviour {

    public float resetTime = 5f;
    public float resetTimer = 0f;

    private void Update ()
    {
        if(transform.localEulerAngles.z > 80 &&
            transform.localEulerAngles.z < 280)
        {
            resetTimer += Time.deltaTime;
        }
        else
        {
            resetTimer = 0f;
        }

        if (resetTimer > resetTime)
        {
            FlippingCar();
        }
    }

    private void FlippingCar()
    {
        transform.rotation = Quaternion.LookRotation(transform.forward);
        transform.position += Vector3.up * 0.5f;
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        resetTimer = 0;
    }
}
