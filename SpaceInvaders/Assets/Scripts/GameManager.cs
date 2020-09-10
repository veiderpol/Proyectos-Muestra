using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour{

    public GameObject alienBlanco, alienAmarillo, alienAzul, naveMorada, naveRoja;
    public int enemyCount;
    Scene activeScene;
    public TextMeshProUGUI textNivel;
   // Start is called before the first frame update
    void Start(){
        activeScene = SceneManager.GetActiveScene();
        enemyCount = 0;
        StartCoroutine("SpawnEnemy","Blanco");
        
    }

    void Update(){
        if(activeScene.name == "Level01"){
            textNivel.text = "Nivel 1";
            if(enemyCount == 10){
                SceneManager.LoadScene("Level02");
            }
        }
        if(activeScene.name == "Level02"){
            textNivel.text = "Nivel 2";
            if(enemyCount == 20){
                SceneManager.LoadScene("Level03");
            }
        }
        if(activeScene.name == "Level03"){
            textNivel.text = "Nivel 3";
            if(enemyCount == 30){
                SceneManager.LoadScene("Level04");
            }
        }
        if(activeScene.name == "Level04"){
            textNivel.text = "Nivel 4";
            if(enemyCount == 40){
                SceneManager.LoadScene("Level05");
            }
        }
        if(activeScene.name == "Level05"){
            textNivel.text = "Nivel 5";
            if(enemyCount == 50){
                SceneManager.LoadScene("Win");
            }
        }
        
    }
    IEnumerator SpawnEnemy(){
        while(true){
            int rand = Random.Range(2,4);
            if(activeScene.name == "Level01" ){
                Instantiate(alienBlanco);
                yield return new WaitForSeconds(rand);
            }
            if (activeScene.name == "Level02" ){
                Instantiate(alienBlanco);
                yield return new WaitForSeconds(rand);
                Instantiate(alienAzul);
                yield return new WaitForSeconds(rand + 0.2f);
            }
            if (activeScene.name == "Level03" ){
                Instantiate(alienBlanco);
                yield return new WaitForSeconds(rand);
                Instantiate(alienAzul);
                yield return new WaitForSeconds(rand + 0.2f);
                Instantiate(alienAmarillo);
                yield return new WaitForSeconds(rand + 0.5f);
            }
            if (activeScene.name == "Level04" ){
                Instantiate(alienBlanco);
                yield return new WaitForSeconds(rand);
                Instantiate(alienAzul);
                yield return new WaitForSeconds(rand + 0.2f);
                Instantiate(alienAmarillo);
                yield return new WaitForSeconds(rand + 0.5f);
                Instantiate(naveMorada);
                yield return new WaitForSeconds(rand + 0.7f);
            }
            if (activeScene.name == "Level05" ){
                Instantiate(alienBlanco);
                yield return new WaitForSeconds(rand);
                Instantiate(alienAzul);
                yield return new WaitForSeconds(rand + 0.2f);
                Instantiate(alienAmarillo);
                yield return new WaitForSeconds(rand + 0.5f);
                Instantiate(naveMorada);
                yield return new WaitForSeconds(rand + 0.7f);
                Instantiate(naveRoja);
                yield return new WaitForSeconds(rand + 0.08f);
            }
            
            
            
        }
    }
}
