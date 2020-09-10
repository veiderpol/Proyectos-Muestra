using UnityEngine;
using System.Collections;

public class PocketsController : MonoBehaviour {
	public GameObject redBalls;
	public GameObject cueBall;
	public AudioSource sonidos;
	public AudioClip entrar;
    public GameObject mensajesGanar;
	private Vector3 originalCueBallPosition;
    public int contadorGanar = 0;
	void Start() {
		originalCueBallPosition = cueBall.transform.position;
	}

	void OnCollisionEnter(Collision collision) {
		sonidos.clip = entrar;
		sonidos.Play();
		Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
		foreach (var transform in redBalls.GetComponentsInChildren<Transform>()) {
			if (transform.name == collision.gameObject.name) {
                contadorGanar++;
				var objectName = collision.gameObject.name;
				GameObject.Destroy(collision.gameObject);

				var ballNumber = int.Parse(objectName.Replace("Ball", ""));
				PoolGameController.GameInstance.BallPocketed(ballNumber);
			}
		}
        if (contadorGanar == 6) {
            mensajesGanar.SetActive(true);
        }
		if (cueBall.transform.name == collision.gameObject.name) {
			cueBall.transform.position = originalCueBallPosition;
			rb.velocity = Vector3.zero;
			rb.angularVelocity = Vector3.zero;
		}
	}
}
