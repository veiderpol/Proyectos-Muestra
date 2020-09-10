using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

using TMPro;
using System.Collections;

public class PlayerController : MonoBehaviour {
	Rigidbody2D rb;
	public GameObject laser;
	float limitX = 3.7f;
	public float velMax = 10f;
	public float velPlayer = 10f;
	public  float hp = 100;
	public TextMeshProUGUI textVida;

	void Start () {
		rb = GetComponent<Rigidbody2D>();
	}
		void FixedUpdate () {
		textVida.text = "Health " + hp.ToString();
		if(hp <= 0){
			SceneManager.LoadScene("GameOver");
		}
		float y = Input.GetAxis("Horizontal");
		rb.velocity = new Vector2(y * velPlayer,0);

		if(rb.velocity.y < -velMax){
			rb.velocity = new Vector2 (-velMax , 0);
		}else if(rb.velocity.y > velMax){
			rb.velocity = new Vector2 (velMax, 0);
		}
		

		if(transform.position.x > limitX){
			transform.position = new Vector2(-limitX,-4.25f);

		}else if(transform.position.x < -limitX){
			transform.position = new Vector2(limitX,-4.25f);
			
		}
		
		if(Input.GetKeyDown(KeyCode.Mouse0)){
			Instantiate (laser, transform.position, Quaternion.Euler(0,0,90));
		}


	}
}
