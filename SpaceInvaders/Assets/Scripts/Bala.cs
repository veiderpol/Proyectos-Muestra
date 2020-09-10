using UnityEngine;
using System.Collections;

public class Bala : MonoBehaviour {
	Rigidbody2D rb;
	public GameObject particule;
	public float force = 5.0f;
	public int damage;
	public int daño;
	GameManager gameManager;

	void Start () {
		gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
		rb = GetComponent<Rigidbody2D> ();
		rb.AddForce (new Vector2 (0, force));
		Destroy (this.gameObject, 1.5f);

	}
	//Se cambia el valor de daño de la bala en el prefab llamado Laser
	void OnTriggerEnter2D(Collider2D other){
		if(other.tag.Equals("Enemy")){
			Enemigo enemigoMove = other.gameObject.GetComponent<Enemigo>();
			enemigoMove.vidaEnemigo -= daño;
			Destroy(this.gameObject);
		}
	}
}