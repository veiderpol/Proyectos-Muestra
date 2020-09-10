using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SiguientePosicionSC : MonoBehaviour
{
    public float tiempoParaTeleport = 2.0f;
    public Image fillRadius;
    public string siguienteEscena;
    public Animator fadeBlackAnim;
    public Transform[] posiciones;

    bool contando = false;
    int posicionActual = 0;

    private void Awake()
    {
        transform.parent.transform.parent = posiciones[0];
        transform.parent.localPosition = Vector3.zero;
        transform.parent.localRotation = new Quaternion(0,0,0,0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Mano")
        {
            contando = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Mano")
        {
            contando = false;
            fillRadius.fillAmount = 0;
        }
    }

    private void Update()
    {
        if (contando)
        {
            fillRadius.fillAmount += Time.deltaTime/tiempoParaTeleport;
            if (fillRadius.fillAmount >= 1)
            {
                contando = false;

                //crear cortina
                fadeBlackAnim.SetTrigger("Cortina");
                
                fillRadius.fillAmount = 0;
                posicionActual++;

                if (!(posicionActual == posiciones.Length))
                {
                    Invoke("Teleport", 0.8f);
                }
                else 
                {
                    SceneManager.LoadSceneAsync(siguienteEscena);
                }

                gameObject.SetActive(false);
            }
        }
    }

    void Teleport()
    {
        transform.parent.transform.parent = posiciones[posicionActual];
        transform.parent.localPosition = Vector3.zero;
        transform.parent.localRotation = new Quaternion(0, 0, 0, 0);
    }
}
