using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlatform : MonoBehaviour {

    // prefabs for platforms to load
    GameObject[] prefabs = new GameObject[3];

    //position to spawn prefab.
    Vector3 position;
    float z = 0;
    float x = 0;
    float min;
    float max;

    // number(s) of platform to spawn
    int platform;
    float amount = 10f;
    public Transform[] platforms;
    bool go;

    public static bool DestroyEverything = false;

	// Use this for initialization
	void Start () {
 
        // load all prefabs
        prefabs[0] = Resources.Load("blueFloor") as GameObject;
        prefabs[1] = Resources.Load("redFloor") as GameObject;
        prefabs[2] = Resources.Load("greenFloor") as GameObject;

        // and spawn the rest
        StartCoroutine(Spawn());

        
    }
	
	// Update is called once per frame
	void Update () {
        
        // this no work, Why?
        platforms = gameObject.GetComponentsInChildren<Transform>();

        //spawn first platform.
        if (DestroyEverything)
        {
            for (var i = 1; i < platforms.Length; i++)
            {
                Destroy(platforms[i].gameObject);
            }

            DestroyEverything = false;
        }

        if(platforms.Length <= 1)
        {
            min = -15f;
            StartCoroutine(Spawn());

        }
    }

    public static void Destroy()
    {
        DestroyEverything = true;
    }

    IEnumerator Spawn()
    {
        //actual spawning
        for(var i = 0; i < amount; i++)
        {
            z = Random.Range(min, max);
            x = Random.Range(-6, 6);
            position = new Vector3(x, 0, z);
            platform = Random.Range(0, 3);
            Instantiate(prefabs[platform], position, Quaternion.identity, GameObject.Find("Platforms").GetComponent<Transform>());
            min += 12;
            max = min + 4;
        }


        // resetting all variables in FloorMovement
        
        //finding all objects
        FloorMovement.redFloor = GameObject.FindGameObjectsWithTag("redFloor");
        FloorMovement.blueFloor = GameObject.FindGameObjectsWithTag("blueFloor");
        FloorMovement.greenFloor = GameObject.FindGameObjectsWithTag("greenFloor");

        // fixing length of startPos arrays with length of Object arrays.
        FloorMovement.startPosGreen = new Vector3[FloorMovement.greenFloor.Length];
        FloorMovement.startPosRed = new Vector3[FloorMovement.redFloor.Length];
        FloorMovement.startPosBlue = new Vector3[FloorMovement.blueFloor.Length];

        // finding all starting positions from all objects
        for (var i = 0; i < FloorMovement.greenFloor.Length; i++)
        {
            FloorMovement.startPosGreen[i] = FloorMovement.greenFloor[i].transform.localPosition;
        }
        for (var i = 0; i < FloorMovement.redFloor.Length; i++)
        {
            FloorMovement.startPosRed[i] = FloorMovement.redFloor[i].transform.localPosition;
        }
        for (var i = 0; i < FloorMovement.blueFloor.Length; i++)
        {
            FloorMovement.startPosBlue[i] = FloorMovement.blueFloor[i].transform.localPosition;
        }
        
        //ten seconds until spawning again
        yield return new WaitForSeconds(10f);
        StartCoroutine(Spawn());    
    }
}
