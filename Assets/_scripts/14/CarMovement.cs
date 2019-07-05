using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour {

    //public Transform CoM;
    //public bool upright = true;
    public Light backlightL, backlightR, strafelightL, strafelightR;
    
    //public Transform wheelFLTrans, wheelFRTrans, wheelRLTrans, wheelRRTrans;

    //public float turnS = 10f;

    public List<AxleInfo> axleInfos; // the information about each individual axle
    public float maxMotorTorque; // maximum torque the motor can apply to wheel
    public float maxSteeringAngle; // maximum steer angle the wheel can have


    private void Start()
    {
        StartCoroutine(Blinkinglights());
    }

    void Update()
    {
        
        if (transform.localEulerAngles.z < 80 ||
            transform.localEulerAngles.z > 280)
        {
            //lights on if driving
            backlightL.enabled = true;
            backlightR.enabled = true;
            strafelightL.enabled = true;
            strafelightR.enabled = true;
        }
        




        //        //// Fl = the turning speed when turning and the FR checks if it needs to turn.
        //        //var FL = x * turnS;

        //        //// cause it is used in pretty much evrything, it's just a variable now.
        //        //var WheelForward = -z * 5 * 360 * Time.deltaTime;

        //        //wheelFLTrans.Rotate(0, WheelForward, 0);
        //        //wheelFRTrans.Rotate(0, WheelForward, 0);
        //        //wheelRLTrans.Rotate(0, WheelForward, 0);
        //        //wheelRRTrans.Rotate(0, WheelForward, 0);

        //        //if (Input.GetAxis("Horizontal")!=0)
        //        //{
        //        //    // turn the wheel with the car
        //        //    wheelFLTrans.localEulerAngles = new Vector3(WheelForward, FL, 90);
        //        //    wheelFRTrans.localEulerAngles = new Vector3(WheelForward, FL, 90);

        //        //    wheelFLTrans.Rotate(0, WheelForward, 0);
        //        //    wheelFRTrans.Rotate(0, WheelForward, 0);
        //        //}




        //        //FL = wheelFL.steerAngle - wheelFLTrans.localEulerAngles.z;
        //        //FR = wheelFR.steerAngle - wheelFRTrans.localEulerAngles.z; 


        //        // Center of Mass
        //        if (null != CoM)
        //        {
        //            GetComponent<Rigidbody>().centerOfMass = CoM.localPosition;
        //        }
    }

    // finds the corresponding visual wheel
    // correctly applies the transform
    public void ApplyLocalPositionToVisuals(WheelCollider collider)
    {
        if (collider.transform.childCount == 0)
        {
            return;
        }

        Transform visualWheel = collider.transform.GetChild(0);

        Vector3 position;
        Quaternion rotation;
        collider.GetWorldPose(out position, out rotation);

        visualWheel.transform.position = position;
        visualWheel.transform.rotation = rotation;
    }

    public void FixedUpdate()
    {
        float motor = maxMotorTorque * Input.GetAxis("Vertical");
        float steering = maxSteeringAngle * Input.GetAxis("Horizontal");

        foreach (AxleInfo axleInfo in axleInfos)
        {
            if (axleInfo.steering)
            {
                axleInfo.leftWheel.steerAngle = steering;
                axleInfo.rightWheel.steerAngle = steering;
            }
            if (axleInfo.motor)
            {
                axleInfo.leftWheel.motorTorque = motor;
                axleInfo.rightWheel.motorTorque = motor;
            }
            ApplyLocalPositionToVisuals(axleInfo.leftWheel);
            ApplyLocalPositionToVisuals(axleInfo.rightWheel);
        }
    }



[System.Serializable]
    public class AxleInfo
    {
        public WheelCollider leftWheel;
        public WheelCollider rightWheel;
        public bool motor; // is this wheel attached to motor?
        public bool steering; // does this wheel apply steer angle?
    }

    IEnumerator Blinkinglights()
    {

        yield return new WaitUntil(() => transform.localEulerAngles.z > 80 &&
            transform.localEulerAngles.z < 280);
        
        backlightL.enabled = false;
        backlightR.enabled = false;
        strafelightL.enabled = false;
        strafelightR.enabled = false;
        yield return new WaitForSeconds(.5f);
             
        backlightL.enabled = true;
        backlightR.enabled = true;
        strafelightL.enabled = true;
        strafelightR.enabled = true;
        yield return new WaitForSeconds(.5f);

        yield return StartCoroutine(Blinkinglights());    
        
    }


}
