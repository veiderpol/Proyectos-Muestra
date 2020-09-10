using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class cueHandler : MonoBehaviour {
	public SteamVR_TrackedObject frontController;
	public SteamVR_TrackedObject backController;
	public Transform cueTip;
	public AudioSource sonidos;
	public AudioClip choqueBlanca;
    public GameObject mensajes;
	private Rigidbody cueRB;
	private Vector3 frontPos;
	private Vector3 backPos;
	private Vector3 cuePos;
	private Vector3 lockForw;
	private float lockOffset;
	// Use this for initialization
	void Start () {
		cueRB = gameObject.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		frontPos = frontController.transform.position;
		backPos = backController.transform.position;
		UpdatePos();
	}

	void UpdatePos(){
		var back = SteamVR_Controller.Input((int)backController.index);
        var front = SteamVR_Controller.Input((int)frontController.index);
        if(back.GetPressDown(SteamVR_Controller.ButtonMask.ApplicationMenu)){
            SceneManager.LoadScene("Main");
        }
        if (front.GetPressDown(SteamVR_Controller.ButtonMask.ApplicationMenu)) {
            SceneManager.LoadScene("Main");
        }
        if (back.GetPressDown(SteamVR_Controller.ButtonMask.Grip)) {
            mensajes.SetActive(false);
        }
        if (front.GetPressDown(SteamVR_Controller.ButtonMask.Grip))
        {
            mensajes.SetActive(false);
        }
        if (back.GetPressDown(SteamVR_Controller.ButtonMask.Trigger)){

			lockForw = transform.up;
			lockOffset = (frontPos - backPos).magnitude;
		}else if(back.GetPress(SteamVR_Controller.ButtonMask.Trigger)){
			float currentOffset = (frontPos - backPos).magnitude;
			cueRB.MovePosition(cuePos + lockForw * (lockOffset - currentOffset));
		}else{
			cuePos = 0.75f * backPos + 0.25f * frontPos;
			cueRB.MovePosition(cuePos);
			cueRB.MoveRotation(Quaternion.LookRotation(frontPos - backPos)* Quaternion.Euler(90f,0f,0f));
		}
	}
	void OnCollisionEnter(Collision col){
		Rigidbody rb = col.gameObject.GetComponent<Rigidbody>();
		sonidos.clip = choqueBlanca;
		sonidos.Play();
		if(!rb){
			return;
		}
		Vector3 forceDirection = (col.contacts[0].point - cueTip.position).normalized;
		Debug.Log ("La fuerza es : " + forceDirection);
		rb.AddForce(forceDirection * cueRB.velocity.magnitude);
		Debug.Log ("La velocidad de la bola es: " + rb.velocity);
	}
}
