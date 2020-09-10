using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Enemigo : MonoBehaviour {
	public GameObject  bala;
	Rigidbody2D rb;
	public float force = -5.0f;
	public float limtX = 3.34f;
	public float velEnemigo;
	float velDisparo;
	public float vidaEnemigo;
	GameManager gameManager;
	GameObject ObjgameManager;
	void Start () {
		gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
		float rand = Random.Range (limtX,-limtX);
		transform.position = new Vector2(rand,5.43f);
		StartCoroutine("SpawnBala");
		
	}

	void Update () {
		Vector3 pos = transform.position;
		//el valor que se le resta a y es la velocidad con la que baja la nave, 
		//este se tiene que modificar en cada prefab de los enemigos
		pos.y -= velEnemigo;
		pos.x = Mathf.Sin (pos.y)*Mathf.PI;
		transform.position = pos;

		if(vidaEnemigo <= 0){
			gameManager.enemyCount++;
			Destroy(this.gameObject);
		}

	} 	
	
	IEnumerator SpawnBala(){
		while(true){
			int rand = Random.Range(1,4);
			yield return new WaitForSeconds(0.8f);
			GameObject aux =  Instantiate(bala, transform.position, Quaternion.Euler(0,0,90));
			aux.transform.parent = this.transform;
		}
	}
}
