using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

    public Transform player;       //Public variable to store a reference to the player game object
    
    public Vector3 offset;         //Private variable to store the offset distance between the player and camera
    
    
    // Use this for initialization
    void Start () 
    {
		player = GameObject.Find("Player").transform;
        //Calculate and store the offset value by getting the distance between the player's position and camera's position.
        //offset = transform.position - player.transform.position;
    }

	void Update() {
		transform.position = new Vector3(player.position.x + offset.x, player.position.y + offset.y, offset.z);
    }
}