using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AutoBall : MonoBehaviour {

    // variables for Ball
    // public static, because it's used by CameraScript2 and Lives
    public static Rigidbody Ball;
    //position variables
    Vector3 StartingPos;
    Transform ResetPos;
    Vector3 FirstPos;
    //collision variables
    public bool grounded = true;
    Transform col;
    
    //variables for UI
    Text Score;
    Text time;
    float points = 0f;
    public static float PlayTime;

    //jump variables
    float jumpForce = 500f;
    AudioSource Boing;

    //fall variables
    [Range(0, 10)]
    float jumpVelocity;

    float fallMultiplier = 2.5f;
    float lowJumpMultiplier = 1f;

    // Use this for initialization
    void Start () {
        // getting necessary components
        Ball = GetComponent<Rigidbody>();
        StartingPos = transform.position;
        FirstPos = transform.position;
        Score = GameObject.Find("Score").GetComponent<Text>();
        time = GameObject.Find("Time").GetComponent<Text>();
        Boing = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {

        //updating the start position
        StartingPos = new Vector3(col.position.x, 0.75f, col.position.z);

        
        //basic movement (automatic)
        transform.Translate(Vector3.forward * 8f * Time.deltaTime);
        

        // updating the playtime for point system and putting the text in right place and format
        PlayTime += Time.deltaTime;
        Score.text = "score: " + points;
        string lastTime = string.Format("{0}:{1:00}", (int)PlayTime / 60, (int)PlayTime % 60);
        time.text = "Time: " + lastTime;
        
        // variable for rotation when using a/d or arrows
        var x = Input.GetAxis("Horizontal");

        // if statement, so only movement and/or jump when grounded
        if (grounded)
        {
            //rotate
            transform.Rotate(Vector3.up * x * 150f * Time.deltaTime);

            //jump
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Boing.Play();
                Ball.AddForce(Vector3.up * Ball.mass * 400f);
                grounded = false;
            }

        }

        //fall motion logic
        if (Ball.velocity.y < 0)
        {
            Ball.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (Ball.velocity.y > 0 && !Input.GetKey(KeyCode.Space))
        {
            Ball.velocity += Vector3.up * Physics.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }

        // if statement where, if Ball comes under certain place it loses a life, 
        // gets placed in the starting position with original rotation and velocity.
        // time get turned off for countDown.
        if (Ball.position.y <= -5f)
        {
            Lives.HP--;
            transform.position = StartingPos;
            transform.localEulerAngles = Vector3.zero;
            Ball.velocity = Vector3.zero;
            Ball.freezeRotation = true;
        }

        //if dead
        if (Lives.HP <= 0)
        {
            SpawnPlatform.Destroy();
            Lives.HP = 3f;
            points = 0f;
            transform.position = FirstPos;
            transform.localEulerAngles = Vector3.zero;
            Ball.velocity = Vector3.zero;
            Ball.freezeRotation = true;
            PlayTime = 0;
            Time.timeScale = 0f;
            CountDown.counter = 3f;
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.transform.tag == "blueFloor" || collision.transform.tag == "redFloor" || collision.transform.tag == "greenFloor")
        {
            
            grounded = true;
            //points and score
            if(collision.transform != col)
            {
                if(PlayTime < 30)
                {
                    points++;
                }
                if(PlayTime >= 30 && PlayTime < 60)
                {
                    points += 2f;
                }
                if(PlayTime >= 60 && PlayTime < 90)
                {
                    points += 3f;
                }
                if(PlayTime >= 90)
                {
                    points += 4f;
                }
                
            }
            col = collision.transform;
        }

        
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.tag == "blueFloor" || collision.transform.tag == "redFloor" || collision.transform.tag == "greenFloor")
        {
            grounded = false;
        }
    }



}
