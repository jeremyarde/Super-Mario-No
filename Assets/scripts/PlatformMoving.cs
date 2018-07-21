using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMoving : MonoBehaviour {

	/*public Transform origin;
	public Transform destination;
	public float speed;
	private Transform[] points;
	private int moveTowards = 1;
	*/
	private int direction = 1;

	public Vector2 velocity = new Vector2(1,0);
	public float rotateSpeed = 0.3f;
	public float rotateY = 1f;
	public float rotateX = 1f;
	public bool clockwise = true;

	private Vector2 centre;
	private float angle;

	void Start(){
		//transform.position = origin.position;
		//points = new Transform[] {origin, destination};
		centre = transform.position;
	}

	void Update() {
		/*transform.position = Vector3.MoveTowards(transform.position, points[moveTowards].position, speed);

		if ( transform.position == origin.position) {
			moveTowards++; //make the platform move towards the destination

			if (moveTowards == points.Length) {
				moveTowards = 0; //move back towards the starting point
			}
		}*/

		//just move the platform in a circle instead, since its not working to move from A - B and back to A from B
		centre += velocity * Time.deltaTime;

        angle += (clockwise ? rotateSpeed : -rotateSpeed) * Time.deltaTime;

        var x = Mathf.Sin(angle) * rotateX;
        var y = Mathf.Cos(angle) * rotateY;

        transform.position = centre + new Vector2(x, y);
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Destination") {
			if (direction == 1) {
				direction = -1;
			}
			else {
				direction = 1;
			}
		}

		//We want to move the player with the platform here
		if (other.tag == "Player") {
			other.transform.parent = transform;
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		if (other.tag == "Player") {
			other.transform.parent = null;
		}
	}
}
