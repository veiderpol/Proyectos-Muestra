using UnityEngine;
using System.Collections;

public class SnookerBallController : MonoBehaviour {
	private Rigidbody ballRB;
	public AudioSource sonidos;
	public AudioClip choque;
	void Start(){
		ballRB = gameObject.GetComponent<Rigidbody>();
	}
	void OnCollisionEnter(Collision col){
		Rigidbody rb = col.gameObject.GetComponent<Rigidbody>();

		if(!rb){
			return;
		}
		Vector3 forceDirection = (col.contacts[0].point).normalized;

		rb.AddForce(forceDirection * ballRB.velocity.magnitude);
		if(col.gameObject.name != "CueBall"){
			sonidos.clip = choque;
			sonidos.Play();
		}
	}
}
