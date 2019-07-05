using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lives : MonoBehaviour {

    // simple livecounter in seperate script, to keep things cleared

    Text livecounter;

    // public and static as it's called inside of AutoBall
    public static float HP = 3f;

    

	// Use this for initialization
	void Start () {
        livecounter = GameObject.Find("Lives").GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        livecounter.text = "Lives: " + HP;

        if(HP < 0)
        {
            Time.timeScale = 0f;
        }
	}
}
