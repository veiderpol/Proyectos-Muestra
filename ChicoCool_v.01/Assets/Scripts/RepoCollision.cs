using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepoCollision : MonoBehaviour{
    Animator anim;
    private PlayerController playerController;
    private ObjectPooler objectPooler;
    GameObject objPooler;
    public GameObject obj, objPlayer;
    float tiempoDelta;
    // Start is called before the first frame update
    void Start(){
        objPooler = GameObject.Find("ObjectPooler");
        objectPooler = objPooler.GetComponent<ObjectPooler>();

        anim = gameObject.GetComponent<Animator>();
        objPlayer = GameObject.Find("CoolDude1");
        playerController = objPlayer.GetComponent<PlayerController>();
    }
    
    void OnTriggerEnter(Collider col){
        if(col.gameObject.CompareTag("Bate")){

            float rand = Random.Range(0,100); 
            anim.SetFloat("AnimMulti",playerController.sliderValue);

            if(this.gameObject.transform.parent.transform.position.x < 0 ){
                Debug.Log("IZQUIERDA");
                if(rand >= 33){
                    anim.SetTrigger("Bate_I_1");
                }else if(rand >= 34 && rand >= 66){
                    anim.SetTrigger("Bate_I_2");
                }else if(rand <= 67){
                    anim.SetTrigger("Bate_I_3");
                }
            }else{
                Debug.Log("DERECHA");
                if(rand >= 33){
                    anim.SetTrigger("Bate_D_1");
                }else if(rand >= 34 && rand >= 66){
                    anim.SetTrigger("Bate_D_2");
                }else if(rand <= 67){
                    anim.SetTrigger("Bate_D_3");
                }
            }
            transform.parent.transform.parent = null;
        }
    }
    void Update(){
        if(objectPooler.runing){
            tiempoDelta += Time.deltaTime;
            this.transform.Rotate(0,Time.deltaTime * 80,0);
            if(tiempoDelta >= 12){
                Destroy(this.transform.parent.gameObject);
            }
        }
    }
    public void YaAcabe(){

    }
}