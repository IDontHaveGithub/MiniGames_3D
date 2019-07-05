using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorMovement : MonoBehaviour {

    //every variable is times three, because there are three colors.

    // it works, so all variables are private now

    // there is standard speed for all gameObjects, just in different variables, because they are changed independently
    public static GameObject[] redFloor;
    public static Vector3[] startPosRed;
    float redSpeed = 3f;
    public static GameObject[] blueFloor;
    public static Vector3[] startPosBlue;
    float blueSpeed = 3f;
    public static GameObject[] greenFloor;
    public static Vector3[] startPosGreen;
    float greenSpeed = 3f;

    float moving = 3f;

    // Use this for initialization
    void Start()
    {
        //finding all gameobjects
        redFloor = GameObject.FindGameObjectsWithTag("redFloor");
        blueFloor = GameObject.FindGameObjectsWithTag("blueFloor");
        greenFloor = GameObject.FindGameObjectsWithTag("greenFloor");

        // fixing length of startPos arrays with length of Object arrays.
        startPosGreen = new Vector3[greenFloor.Length];
        startPosRed = new Vector3[redFloor.Length];
        startPosBlue = new Vector3[blueFloor.Length];

        // finding all starting positions from all objects
        for (var i = 0; i < greenFloor.Length; i++)
        {
            startPosGreen[i] = greenFloor[i].transform.localPosition;
        }
        for (var i = 0; i < redFloor.Length; i++)
        {
            startPosRed[i] = redFloor[i].transform.localPosition;
        }
        for (var i = 0; i < blueFloor.Length; i++)
        {
            startPosBlue[i] = blueFloor[i].transform.localPosition;
        }
    }

    void Update()
    {

        // movement for all floors at different times, as asked, 
        // not as if you'll even survive for more than 15 seconds.
        if (AutoBall.PlayTime >= 30f)
        {
            for (var i = 0; i < greenFloor.Length; i++)
            {

                greenFloor[i].transform.Translate(Vector3.right * greenSpeed * Time.deltaTime);
                //greenFloor[i].transform.Translate(move);

                var mostRight = startPosGreen[i].x + moving;
                var mostLeft = startPosGreen[i].x - moving;

                if (greenFloor[i].transform.localPosition.x <= mostLeft || greenFloor[i].transform.localPosition.x >= mostRight)
                {
                    greenSpeed = -greenSpeed;
                }
            }
        }

        if (AutoBall.PlayTime >= 60f)
        {
            for (var i = 0; i < redFloor.Length; i++)
            {
                redFloor[i].transform.Translate(Vector3.right * redSpeed * Time.deltaTime);
                //redFloor[i].transform.Translate(move);

                var mostRight = startPosRed[i].x + moving;
                var mostLeft = startPosRed[i].x - moving;

                if (redFloor[i].transform.localPosition.x <= mostLeft || redFloor[i].transform.localPosition.x >= mostRight)
                {
                    redSpeed = -redSpeed;
                }


            }
        }

        if (AutoBall.PlayTime >= 90f)
        {
            for (var i = 0; i < blueFloor.Length; i++)
            {
                blueFloor[i].transform.Translate(Vector3.right * blueSpeed * Time.deltaTime);
                //blueFloor[i].transform.Translate(move);

                var mostRight = startPosBlue[i].x + moving;
                var mostLeft = startPosBlue[i].x - moving;

                if (blueFloor[i].transform.localPosition.x <= mostLeft || blueFloor[i].transform.localPosition.x >= mostRight)
                {
                    blueSpeed = -blueSpeed;
                }


            }
        }
    }
}
