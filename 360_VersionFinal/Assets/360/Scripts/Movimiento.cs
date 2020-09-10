using UnityEngine;
using System.Collections;

public class Movimiento : MonoBehaviour {
	private float initialYAngle = 0f;
	private Gyroscope gyro;
	private Quaternion gyroAttitude;
	private bool gyroSupport;
	private bool gyroEnabled;
	public float speed = 4.0f;
	public float sensitivity = 0.8f; 
	[HideInInspector]
	public Quaternion rotacion;
	void Start()
	{
		gyroSupport = SystemInfo.supportsGyroscope;

		if (gyroSupport) {
			gyro = Input.gyro;
			gyroEnabled = true;
			gyro.enabled = true;
		} else {
			gyroEnabled = false;
			print ("NO GYRO");
		}

		ApplyCalibration ();
	}

	void Update()
	{
		if (gyroEnabled) {
			ApplyGyroRotation ();
		}
		rotacion = transform.localRotation;
	}

	void ApplyGyroRotation()
	{
		Quaternion newRotation = Quaternion.Slerp(gyroAttitude,
			Input.gyro.attitude, 
			Time.deltaTime * speed * sensitivity);

		transform.localRotation = newRotation;

		transform.Rotate( 30f, 0f, 180f, Space.Self ); 
		transform.Rotate( 90f, 180f, 0f, Space.World );


		gyroAttitude = newRotation;
	}

	void ApplyCalibration()
	{        
		transform.localRotation = Input.gyro.attitude;
		transform.Rotate( 30f, 0f, 180f, Space.Self ); 
		transform.Rotate( 90f, 180f, 0f, Space.World ); 

		initialYAngle = transform.eulerAngles.y; 
	}


	public float GetYAngle() {
		ApplyCalibration ();

		return initialYAngle;
	}
}

