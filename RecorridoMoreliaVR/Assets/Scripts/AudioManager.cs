using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(AudioSource))]

public class AudioManager : MonoBehaviour{
     AudioSource listener;

    public GameObject teletransportacion;

    int index = 0;
    public AudioClip [] audios;
    public Animator catrin;
    // Start is called before the first frame update
    void Start(){
        listener = GetComponent<AudioSource>();
        StartCoroutine(""+SceneManager.GetActiveScene().name);
    }

    // Update is called once per frame
    void Update(){
        
    }

    IEnumerator LaManzanillera(){
        yield return new WaitForSeconds(2);
        listener.Pause();
        listener.clip = audios[index];
        listener.Play();
        catrin.SetBool("Hablando", true);
        yield return new WaitForSeconds(listener.clip.length);
        catrin.SetBool("Hablando", false);
        catrin.SetBool("Idle", true);
        StartCoroutine("TP");
    }

    IEnumerator TP(){
        Debug.Log(index);
        teletransportacion.SetActive(true);
        yield return new WaitForSeconds(5);
        teletransportacion.SetActive(false);

        if (index < 4) {
            StartCoroutine("TP");
            index++;
        }
    }
}
