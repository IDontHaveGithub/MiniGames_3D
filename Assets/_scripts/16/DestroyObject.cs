using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour {

    AudioSource Boom;
    

	// Use this for initialization
	void Start () {
        Boom = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {

        

        //destroying gameobject that gets too low.
        if (transform.position.y < -3f)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "Player1" || collision.transform.tag == "Player2")
        {
            Boom.Play();
        }
        
    }
}
