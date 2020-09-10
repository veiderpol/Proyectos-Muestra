using UnityEngine;
using System.Collections;

public class BalaEnemiga : MonoBehaviour {
	Rigidbody2D rb;
	public float force = 5.0f;
	PlayerController playerController;
	public GameObject PlayerController;
	
	//cambiar el daño en el prefab de laseEnemigo, en la carpeta Prefabs
	public float dañoBlanco, dañoAzul, dañoAmarillo, dañoMorado, dañoRojo;

	void Start () {
		playerController = GameObject.Find("Player").GetComponent<PlayerController>();
		rb = GetComponent<Rigidbody2D> ();
		rb.velocity =  new Vector2 (0, -force);
		Destroy (this.gameObject, 2.5f);
	}
	//Para cambiar el daño que hace cada uno de los enemigos, se cambia dentro del prefab de laserEnemigo
	void OnTriggerEnter2D(Collider2D other){
		if(other.tag.Equals("Player")){
			if(this.transform.parent.name == "AlienBlanco(Clone)"){
				playerController.hp -= dañoBlanco;
			}
			if(this.transform.parent.name == "AlienAzul(Clone)"){
				playerController.hp -= dañoBlanco;
			}
			if(this.transform.parent.name == "AlienAmarillo(Clone)"){
				playerController.hp -= dañoBlanco;
			}
			if(this.transform.parent.name == "NavecitaMorada(Clone)"){
				playerController.hp -= dañoBlanco;
			}
			if(this.transform.parent.name == "NavecitaRoja(Clone)"){
				playerController.hp -= dañoBlanco;
			}
		}
	}
}