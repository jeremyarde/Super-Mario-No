using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportA : MonoBehaviour {

	//public GameObject player;
	public Transform target;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other) {
		Rigidbody2D otherRB = other.GetComponent<Rigidbody2D>();
		otherRB.Sleep(); //remove collisions so we can move through walls and things
		otherRB.velocity = Vector3.zero;
		other.transform.rotation = target.transform.rotation;

		other.transform.position = target.transform.position;
		//transform.rotation = new Quaternion(0, 0, 0, 0);
		//other.GetComponent<Rigidbody2D>().velocity = new Vector3(0,0,0);

		Debug.Log("Teleport hit");
	}
}
