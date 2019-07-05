using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovePlayer2 : MonoBehaviour {

    //gameobjects to load prefabs correctly, rigidbodies to move them, array for rigibodies to count points.
    public GameObject prefabOne, prefabTwo;
    public Rigidbody playerOne, playerTwo;
    public Rigidbody[] players;

    float pointPOne = 0f, pointPTwo = 0f;
    
    Text Score;

    Vector3 startPos1 = new Vector3(9, .6f, 0);
    Vector3 startPos2 = new Vector3(-9, .6f, 0); 

    private void Start()
    {
        //loading prefabs
        prefabOne = Resources.Load("Player1") as GameObject;
        prefabTwo = Resources.Load("Player2") as GameObject;

        
        //text component for scores
        Score = GameObject.Find("Score").GetComponent<Text>();
    }

    void Update()
    {
        //keeping score
        Score.text = pointPTwo + " : " + pointPOne;

        //instantiating prefabs and finding their rigidbodies.
        if (players.Length == 0)
        {
            Instantiate(prefabTwo, startPos2, Quaternion.Euler(0, 90, 0), GameObject.Find("Players").GetComponent<Transform>());
            Instantiate(prefabOne, startPos1, Quaternion.Euler(0, -90, 0), GameObject.Find("Players").GetComponent<Transform>());

            playerOne = GameObject.FindGameObjectWithTag("Player1").GetComponent<Rigidbody>();
            playerTwo = GameObject.FindGameObjectWithTag("Player2").GetComponent<Rigidbody>();
        }

        // since the objects just get destroyed when under certain height, players needs to stay updated
        players = GetComponentsInChildren<Rigidbody>();
        
        // count point, make new player and place other player back at it's starting point.
        if (players.Length == 1)
        {
            if (players[0].tag == "Player1")
            {
                //get points
                pointPOne++;
                //restart living player
                playerOne.transform.localPosition = startPos1;
                playerOne.transform.localEulerAngles = new Vector3(0,-90,0);
                playerOne.velocity = Vector3.zero;
                playerOne.freezeRotation = true;
                playerOne.freezeRotation = false;
                //respawn dead
                Instantiate(prefabTwo, startPos2, Quaternion.Euler(0, 90, 0), GameObject.Find("Players").GetComponent<Transform>());
                playerTwo = GameObject.FindGameObjectWithTag("Player2").GetComponent<Rigidbody>();
            }
            if (players[0].tag == "Player2")
            {
                // get points
                pointPTwo++;
                //restart living player
                playerTwo.transform.localPosition = startPos2;
                playerTwo.transform.localEulerAngles = new Vector3(0, 90, 0);
                playerTwo.velocity = Vector3.zero;
                playerTwo.freezeRotation = true;
                playerTwo.freezeRotation = false;
                //respawn dead
                Instantiate(prefabOne, startPos1, Quaternion.Euler(0, -90, 0), GameObject.Find("Players").GetComponent<Transform>());
                playerOne = GameObject.FindGameObjectWithTag("Player1").GetComponent<Rigidbody>();
            }
        }

        // turnS is turning speed and force is force added when going forward.
        var turnS = Time.deltaTime * 90.0f;
        var force = 600.0f;

        //movement player 1
        if (Input.GetKey(KeyCode.RightArrow))
        {
            playerOne.transform.Rotate(Vector3.up * turnS);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            playerOne.transform.Rotate(Vector3.down * turnS);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            playerOne.AddForce(playerOne.transform.forward * force);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            playerOne.AddForce(playerOne.transform.forward * -force / 2);
        }

        // movement player 2
        if (Input.GetKey(KeyCode.D))
        {
            playerTwo.transform.Rotate(Vector3.up * turnS);
        }
        if (Input.GetKey(KeyCode.A))
        {
            playerTwo.transform.Rotate(Vector3.down * turnS);
        }
        if (Input.GetKey(KeyCode.W))
        {
            playerTwo.AddForce(playerTwo.transform.forward * force);
        }
        if (Input.GetKey(KeyCode.S))
        {
            playerTwo.AddForce(playerTwo.transform.forward * -force / 2);
        }
        
    }

}
