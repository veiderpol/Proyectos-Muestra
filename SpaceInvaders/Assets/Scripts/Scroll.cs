using UnityEngine;
using System.Collections;

public class Scroll : MonoBehaviour {
	public float speed = 0.5f;
	void Start () {
	
	}

	void Update () {
		Vector2 back = new Vector2 (0,Time.time * speed);
		gameObject.GetComponent<Renderer> ().material.mainTextureOffset = back;
	}
}
