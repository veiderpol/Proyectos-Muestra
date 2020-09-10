using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovimientoSegundaCamara : MonoBehaviour {
	private float initialYAngle = 0;
	private Gyroscope gyro;
	private Quaternion gyroAttitude;
	private bool gyroSupport;
	private bool gyroEnabled;
	public float speed = 4.0f;
	public float sensitivity = 0.8f; 
	public float offsety =180;
	public float offsetx = 90;
	public float offsetz = 0;

	private Movimiento movimiento;
	public Transform extraRotation;

	void Start()
	{
		movimiento = FindObjectOfType<Movimiento> ();
		
	}
	void LateUpdate()
	{
		transform.localRotation = movimiento.rotacion;
		transform.localRotation *= extraRotation.rotation;
	}

}
