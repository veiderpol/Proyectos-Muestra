using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Cargar : MonoBehaviour {

	public GameObject Imagen;

	public void Reinicio(){
		SceneManager.LoadScene("Level01");
	}
	public void Salir(){
		Application.Quit();
	}
}
