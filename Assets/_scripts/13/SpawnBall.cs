using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBall : MonoBehaviour {

    public GameObject prefab;

	// Use this for initialization
	void Start () {
        foreach (Transform child in transform)
        {
            GameObject ball = Instantiate(prefab, child.transform.position, Quaternion.identity) as GameObject;
            
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
