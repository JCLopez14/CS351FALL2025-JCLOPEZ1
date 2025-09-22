using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class canFollowEachPlayer : MonoBehaviour
{
    //Set this Refrence in the Inspector
    public GameObject player;


    // Update is called once per frame
    void Update()
    {
        //set the position of cam to player position
        transform.position = new Vector3(
            player.transform.position.x,
            player.transform.position.y,
            transform.position.z);


    }
}
