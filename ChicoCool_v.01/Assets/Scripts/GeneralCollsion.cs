using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralCollsion : MonoBehaviour{
    private ObjectPooler objectPooler;
    public GameObject repoGameObj, objObjectPooler;
    void Awake(){
        objectPooler = objObjectPooler.GetComponent<ObjectPooler>();
    } 
    void OnTriggerEnter(Collider other){
        if (other.gameObject.CompareTag("Pared")){
            other.gameObject.SetActive(false);
        }
        if(other.gameObject.CompareTag("RespoM")){
            objectPooler.ControlVidas();
        }
        if(other.gameObject.CompareTag("Respo")){
            objectPooler.puntuaje += 100;
            Debug.Log(objectPooler.puntuaje);
        }     
    }
    void OnCollisionEnter(Collision other){
        if(other.gameObject.CompareTag("Respo")){
        }
    }
}
