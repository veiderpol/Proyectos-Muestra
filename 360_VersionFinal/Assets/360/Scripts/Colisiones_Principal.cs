using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Colisiones_Principal : MonoBehaviour {
	public Animator anim;
	public Animator anim_Camera;
	public bool desActBos = false,desActRio = false,desActCamp = false,desActMon = false;
	public bool bosque = true; 
	public bool rio = false; 
	public bool campo_de_cultivo = false; 
	public bool montaña = false; 
	public Button boton;
	public GameObject botonInfinito;
	public GameObject visor;
	public GameObject visor_Canvas;
	Collider cubo_Visor;
	GameObject gameObjAux;
	Collider colision;
	public Image imageSprite;
	public Image imageSpriteInf;
	public Sprite newSprite;
	public Sprite oldSprite;
	public int numeroAudio;
	public AudioSource audioSource;
	public AudioSource audioBoton;
	public AudioClip[] d_AudioClip;
	public AudioClip[] e_AudioClip;
	public bool audio_1 = false,audio_1_seguir = false, audio_terminar = false, activar_Boton = true;
	public bool activar = true;

	void Start(){
		StartCoroutine(PlayAudio(numeroAudio));
		cubo_Visor = gameObject.GetComponent<Collider>();
		cubo_Visor.enabled = false;
		activar = true;
	}
	void OnTriggerEnter(Collider col){
		gameObjAux = col.gameObject;
		colision = col;
		//Bosque
		if (col.gameObject.tag.Equals ("Tag1")) {
			bosque = true;
			desActBos = true;
			numeroAudio = 1;
			gameObjAux.SetActive(false);
			StartCoroutine(PlayAudio(numeroAudio));
		}
		//Rio
		if (col.gameObject.tag.Equals ("Tag2")&&(!rio)&&(bosque)&&(!campo_de_cultivo)&&(!montaña)) {
			rio = true;
			boton.gameObject.SetActive (true);
		}
		//Campo de cultivo
		if (col.gameObject.tag.Equals ("Tag3")&&(!campo_de_cultivo)&&(bosque)&&(rio)&&(!montaña)) {
			campo_de_cultivo = true;
			boton.gameObject.SetActive (true);
		}
		//Montaña
		if (col.gameObject.tag.Equals ("Tag4")&&(!montaña)&&(bosque)&&(rio)&&(campo_de_cultivo)){
			montaña = true;
			boton.gameObject.SetActive (true);
		}
	}
	void OnTriggerExit(Collider col){
		if((!desActBos)||(!desActRio)||(!desActCamp)||(!desActMon)){
			bosque = false;
			rio = false;
			campo_de_cultivo = false;
			montaña = false;
		}
		if(desActBos){
			bosque = true;
			rio = false;
			campo_de_cultivo = false;
			montaña = false;
		}
		if(desActRio){
			bosque =  true;
			rio = true;
			campo_de_cultivo = false;
			montaña = false;
		}
		if(desActCamp){
			bosque =  true;
			rio = true;
			campo_de_cultivo = true;
			montaña = false;
		}

		boton.gameObject.SetActive (false);	
	}
	public void ActivarVisor(){
		StopAllCoroutines();
		audioBoton.Play();
		visor.SetActive (true);
		visor_Canvas.SetActive(true);
		imageSprite.sprite = newSprite;
		
		
		if(rio && desActBos && !desActCamp && !desActRio && !desActMon){
			desActRio = true;
			numeroAudio = 2;
			StartCoroutine(PlayAudio(numeroAudio));
		
		}
		if(campo_de_cultivo && desActRio && desActBos && !desActCamp){
			desActCamp = true; 
			numeroAudio = 3;
		    StartCoroutine(PlayAudio(numeroAudio));	
		}

		if(montaña && desActCamp && desActRio && desActBos && !desActMon){
			numeroAudio = 4;
			StartCoroutine(PlayAudio(numeroAudio));	
		}
		if(desActMon){
			if(activar){
				StartCoroutine(BotonInfinito_Activar());
			}else if(!activar){
				StartCoroutine(BotonInfinito());
			}
		}
	}
	IEnumerator BotonInfinito_Activar(){
		activar = false;
		imageSpriteInf.sprite = newSprite;
		anim.SetBool("Activar_Canvas",true);
		anim_Camera.SetBool("Activar_Camera",true);
		visor.SetActive (true);
		visor_Canvas.SetActive(true);
		yield return new WaitForSeconds(1.5f);
	}
	IEnumerator BotonInfinito(){
		activar = true;
		imageSpriteInf.sprite = oldSprite;
		anim.SetBool("Activar_Canvas",false);
		anim_Camera.SetBool("Activar_Camera",false);
		yield return new WaitForSeconds(1f);
		visor.SetActive(false);
		visor_Canvas.SetActive(false);
	}
	IEnumerator PlayAudio(int numeroAudio){
		//gameObjAux.SetActive(false);
		yield return new WaitForSeconds(0);
		//activar_Boton =  false;
		cubo_Visor.enabled = false;		
		boton.interactable  = false ;
		anim.SetBool("Activar_Canvas",true);
		anim_Camera.SetBool("Activar_Camera",true);
		audioSource.clip = e_AudioClip[numeroAudio];
		audioSource.Play();
		yield return new WaitForSeconds(audioSource.clip.length);
		audioSource.clip = d_AudioClip[numeroAudio];
		audioSource.Play();

		yield return new WaitForSeconds(audioSource.clip.length);
		if(numeroAudio == 0){
			
			visor.SetActive (true);
			visor_Canvas.SetActive(true);
			anim.SetBool("Activar_Canvas",true);
		    anim_Camera.SetBool("Activar_Camera",true);
		    cubo_Visor.enabled = true;	
		
		}else{
			anim.SetBool("Activar_Canvas",false);
			anim_Camera.SetBool("Activar_Camera",false);
			cubo_Visor.enabled = true;
		
			if(numeroAudio == 4){
				audioSource.clip = e_AudioClip[5];
				audioSource.Play();
				botonInfinito.SetActive(true);
				desActMon =  true;
			}
			yield return new WaitForSeconds(1.0f);
			imageSprite.sprite = oldSprite;
			visor.SetActive(false);
			visor_Canvas.SetActive(false);
			boton.interactable = true;
			boton.gameObject.SetActive(false);
			//activar_Boton = true;
		}
		
	}
}
