using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reset_bola : MonoBehaviour
{
    public Vector3 posOrg;
    void Start(){
        posOrg = new Vector3(this.gameObject.transform.position.x,this.gameObject.transform.position.y,this.gameObject.transform.position.z);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Piso"){
            this.transform.position = new Vector3(posOrg.x,posOrg.y,posOrg.z);
        }
    }
}
