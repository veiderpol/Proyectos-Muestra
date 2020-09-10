using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]


public class BocaManager : MonoBehaviour{

    public AudioSource listener;
    int cont = 0;
    public AudioClip [] audiosPlatos;
    // Start is called before the first frame update
    void Start(){

    }

    // Update is called once per frame
    void Update(){
        
    }

    void OnTriggerEnter(Collider other){
        switch(other.gameObject.name){
            case "Uchepos":
                Debug.Log(other.gameObject.name);
                listener.clip = audiosPlatos[1];
                Destroy(other.gameObject);

                break;
            case "Corundas":
                Debug.Log(other.gameObject.name);
                listener.clip = audiosPlatos[2];
                Destroy(other.gameObject);

                break;
            case "Carnitas":
                Debug.Log(other.gameObject.name);
                listener.clip = audiosPlatos[0];
                Destroy(other.gameObject);

                break;
            case "Pozole":
                Debug.Log(other.gameObject.name);
                listener.clip = audiosPlatos[3];
                Destroy(other.gameObject);

                break;
            case "Sopa Tarasca":
                Debug.Log(other.gameObject.name);
                listener.clip = audiosPlatos[5];
                Destroy(other.gameObject);

                break;
            case "Morisqueta":
                Debug.Log(other.gameObject.name);
                listener.clip = audiosPlatos[4];
                Destroy(other.gameObject);

                break;
        }
        listener.Pause();
        listener.Play();
    }
}


