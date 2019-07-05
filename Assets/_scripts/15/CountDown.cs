using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDown : MonoBehaviour {

    public Text Count;
    Text Starter;

    public static float counter = 3f;
    bool go = true;


    // Use this for initialization
    void Start () {
        Count = GameObject.Find("CountDown").GetComponent<Text>();
        Starter = GameObject.Find("Starting").GetComponent<Text>();

        Time.timeScale = 0f;
        StartCoroutine(counting());
    }
	
	// Update is called once per frame
	void Update () {

        if(counter == 3f)
        {
            go = true;
        }
        else
        {
            go = false;
        }
        
	}

    // simple countdown
    public IEnumerator counting()
    {
        Count.text = "" + counter;

        if(counter <= 0f)
        {
            Time.timeScale = 1f;
            Count.text = "Start";
            Starter.enabled = false;
            yield return new WaitForSeconds(1.5f);
            Count.enabled = false;

            // waiting to start over until counter is 3 again.
            yield return new WaitUntil(() => go);
            StartCoroutine(counting());
        }
        else
        {
            Starter.enabled = true;
            Count.enabled = true;
            yield return new WaitForSecondsRealtime(1f);
            counter--;
            StartCoroutine(counting());
        }

        
        //every second a number less.
        
        // only starting over if counter is more than 0
                     
    }
}
 