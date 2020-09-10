using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereRotation : MonoBehaviour{
    private ObjectPooler objectPooler;
    public GameObject objPooler;
    void Start(){
        objPooler = GameObject.Find("ObjectPooler");
        objectPooler = objPooler.GetComponent<ObjectPooler>();
    }
    void FixedUpdate(){
        if(objectPooler.runing){
            transform.Rotate(Time.deltaTime * -13,0,0);
        }
    }
}
