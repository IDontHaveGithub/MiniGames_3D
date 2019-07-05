using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{

    // who to follow
    public Transform Target;

    // how fast to follow
    public float speed = 0.125f;

    // only if you don't want the camera to be centered, otherwise just 0.
    

    void FixedUpdate()
    {
     
        // to get the not centered right, when you look the other way.
        Vector3 desiredPos = new Vector3(Target.position.x+5,Target.position.y+3 ,Target.position.z);
        Vector3 smoothPos = Vector3.Lerp(transform.position, desiredPos, 0.05f);
        transform.position = smoothPos;
        

    }

    //constantly check for player.
    public void Update()
    {
        if (Target == null)
        {
            FindPlayer(true);
            return;
        }
    }

    // when the player dies, it gets respawned, but the player object is gone for a bit, this way you'll find the player again.
    public void FindPlayer(bool findSwitch)
    {
        if (findSwitch == true)
        {
            GameObject searchResult = GameObject.FindGameObjectWithTag("Player");
            if (searchResult != null)
            {
                Target = searchResult.transform;
            }
            findSwitch = false;
        }

    }
}
