using UnityEngine;
using System.Collections;

public class PoolGameController : MonoBehaviour {
	public GameObject cue;
	public GameObject cueBall;
	public GameObject redBalls;
	public GameObject mainCamera;
	public GameObject scoreBar;
	public GameObject winnerMessage;

	public float maxForce;
	public float minForce;
	public Vector3 strikeDirection;

	public const float MIN_DISTANCE = 27.5f;
	public const float MAX_DISTANCE = 32f;

	private bool currentPlayerContinuesToPlay = false;

	// This is kinda hacky but works
	static public PoolGameController GameInstance {
		get;
		private set;
	}

	void Start() {
		strikeDirection = Vector3.forward;

		GameInstance = this;
		winnerMessage.GetComponent<Canvas>().enabled = false;
	}

	public void BallPocketed(int ballNumber) {
		currentPlayerContinuesToPlay = true;
	}

}
