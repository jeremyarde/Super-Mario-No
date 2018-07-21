using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class VehicleController : MonoBehaviour {

    public WheelJoint2D frontwheel;	//Set the wheel joints inside of unity itself, by dragging
	public WheelJoint2D backwheel;

	JointMotor2D motorFront;	//Just adding references for use later
	JointMotor2D motorBack;

	public float speedF;
	public float speedB;
	public float torqueF;
	public float torqueB;
	public bool TractionFront = true;
	public bool TractionBack = true;
	public float carRotationSpeed;

	
	// Update is called once per frame
	void Update () {
		
		//Moving the car forwards
		if (Input.GetAxisRaw ("Vertical") > 0) {
			if (TractionFront) {
				motorFront.motorSpeed = speedF * -1;
				motorFront.maxMotorTorque = torqueF;
				frontwheel.motor = motorFront;
			}

			if (TractionBack) {
				motorBack.motorSpeed = speedF * -1;
				motorBack.maxMotorTorque = torqueF;
				backwheel.motor = motorBack;

			}

		} 

		//Moving the car backwards
		else if (Input.GetAxisRaw ("Vertical") < 0) {
			if (TractionFront) {
				motorFront.motorSpeed = speedB * -1;
				motorFront.maxMotorTorque = torqueB;
				frontwheel.motor = motorFront;
			}

			if (TractionBack) {
				motorBack.motorSpeed = speedB * -1;
				motorBack.maxMotorTorque = torqueB;
				backwheel.motor = motorBack;
                
			}

		} 
		//Turn off the motor
		else {
			backwheel.useMotor = false;
			frontwheel.useMotor = false;
		}

		//Ability to move the car in air
		if (Input.GetAxisRaw ("Horizontal") != 0) {
			GetComponent<Rigidbody2D>().AddTorque(carRotationSpeed * Input.GetAxisRaw ("Horizontal"));
		}

        if ( Input.GetKeyDown("r") )
        {
            Debug.Log("restarting scene");
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

		}

        if (Input.GetKey("escape")) {
            SceneManager.LoadScene(0);
		}
	}
}