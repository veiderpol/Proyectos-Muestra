using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerController : MonoBehaviour{
    public GameObject bateI, bateD;
    private ObjectPooler objectPooler;
    GameObject objPooler;
    public Animator anim;
    public Slider slider;
    public Image imgFill;
    bool bandera;
    Color imgColor;
    public float sliderValue;
    void Start(){
        objPooler = GameObject.Find("ObjectPooler");
        objectPooler = objPooler.GetComponent<ObjectPooler>();
        anim = GetComponent<Animator>();
    }
    void Update(){
        if(objectPooler.runing){
            
            if(Input.touchCount >= 1){
            
                if(slider.value == 1){
                        bandera = true;                
                }else if(slider.value == 0){
                    bandera = false;
                }
                if(bandera){
                    slider.value -= Time.deltaTime;
                }else{
                    slider.value += Time.deltaTime;
                }
                imgColor = Color.Lerp(Color.green, Color.red,slider.value);
                imgFill.color = imgColor;

                for(int i = 0; i < Input.touchCount; i++){
                    if(Input.touchCount == 2){
                        if(Input.GetTouch(0).position.x < Screen.width / 2 && Input.GetTouch(1).position.x > Screen.width / 2){
                            Debug.Log("LOOOOL");
                        }
                    }
                    if(Input.GetTouch(0).phase == TouchPhase.Began){
                        if(Input.GetTouch(0).position.x < Screen.width / 2){
                            bateI.SetActive(true);
                            bateD.SetActive(false);
                            anim.SetBool("PreDB",false);
                            anim.SetBool("AccionIB",false);
                            anim.SetBool("Termino",false);
                            anim.SetBool("PreIB",true);
                        }
                        if(Input.GetTouch(0).position.x > Screen.width / 2){
                            bateD.SetActive(true);
                            bateI.SetActive(false);
                            anim.SetBool("PreIB",false);
                            anim.SetBool("AccionDB",false);
                            anim.SetBool("Termino",false);
                            anim.SetBool("PreDB",true);
                        }
                    }
                    if(Input.GetTouch(0).phase == TouchPhase.Ended){
                        sliderValue = slider.value;
                        sliderValue = sliderValue * 5f;
                        if(Input.GetTouch(0).position.x < Screen.width / 2){ 
                            slider.value = 0;
                            anim.SetBool("PreIB",false);
                            anim.SetBool("PreDB",false);
                            anim.SetBool("AccionIB",true);
                            anim.SetBool("Termino",true);
                        }
                        if(Input.GetTouch(0).position.x > Screen.width / 2){
                            slider.value = 0;
                            anim.SetBool("PreDB",false);
                            anim.SetBool("PreIB",false);
                            anim.SetBool("AccionDB",true);
                            anim.SetBool("Termino",true);
                        }
                    }
                }
            }

        }
        
    }
}
