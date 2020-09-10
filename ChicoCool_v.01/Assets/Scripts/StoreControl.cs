using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;
using System.IO;
using LitJson;
using System;
using TMPro;
public class StoreControl : MonoBehaviour{
    public GameObject[] skins;
    public GameObject objData;
    private JsonData itemData;
    TextMeshProUGUI textSkin;
    public TextMeshProUGUI textCoin;
    public int coins, aux = 0;
    List<String> playerList = new List<String>();
    public Button atras, adelante;
    Player player;
    private static Data data;
    public Texture[]  textures; 
    public Material playerMaterial;
    string actual_skin, jsonString;

    void Start(){
        Scene scene = SceneManager.GetActiveScene();
        
        if(scene.name == "Menu"){
            string filePath = Path.Combine(Application.persistentDataPath, "PlayerStats.json");
            if(!File.Exists(filePath)){
                WWW www = new WWW("jar:file://" + Application.dataPath + "!/assets/" + "PlayerStats.json");
                File.WriteAllBytes(filePath, www.bytes);
            }
            jsonString = File.ReadAllText(Application.persistentDataPath + "/PlayerStats.json");
            data = FindObjectOfType<Data>();
            itemData = JsonMapper.ToObject(jsonString);
            coins = Convert.ToInt32(itemData["coins"].ToString());
            coins += data.monedas;
            Inicio();
        }
        
    }
    public void Inicio(){
        player = new Player(actual_skin,coins, playerList);
        itemData = JsonMapper.ToObject(jsonString);
    
        actual_skin = itemData["actual_skin"].ToString();
        for(int i = 0 ; i < textures.Length ; i++ ){
            if(textures[i].name == actual_skin){
                playerMaterial.SetTexture("_MainTex", textures[i]);
            }
        }

        textCoin.SetText("Coins: " + coins);  

        for(int j = 0 ; j < itemData["skins"].Count ; j++){
            for(int i = 0 ; i < skins.Length ; i++){
                if(skins[i].name == itemData["skins"][j].ToString()){
                    textSkin = skins[i].gameObject.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();
                    textSkin.alpha = 194f; 
                    skins[i].gameObject.transform.GetChild(1).gameObject.SetActive(true);
                    skins[i].gameObject.transform.GetChild(2).gameObject.SetActive(false);
                    if(!playerList.Contains(skins[i].name)){
                        playerList.Add(skins[i].name);
                    }
                }  
            }
        }
    }

    public void Adelante(Button boton){
        if(boton.name == "Adelante"){
            if(aux < 4){
                skins[aux].SetActive(false);
                aux += 1;
                skins[aux].SetActive(true);
            }
            if(aux == 4){
                boton.interactable = false;
            }
        }else if(boton.name == "Atras"){
            if(aux >  0){
                skins[aux].SetActive(false);
                aux -= 1;
                skins[aux].SetActive(true);
                boton.interactable = true;
            }   
            if(aux == 0){
                boton.interactable = false;
            }     
        }
        int costOfSkins = Convert.ToInt32(skins[aux].gameObject.transform.GetChild(2).gameObject.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text);
        playerMaterial.SetTexture("_MainTex", textures[aux]);
        if (skins[aux].gameObject.transform.GetChild(1).gameObject.activeSelf){
            Texture tex = playerMaterial.GetTexture("_MainTex");
            actual_skin = tex.name;
        }

        if(costOfSkins > coins){
            skins[aux].gameObject.transform.GetChild(2).GetComponent<Button>().interactable = false;
        }else{
            skins[aux].gameObject.transform.GetChild(2).GetComponent<Button>().interactable = true;
        }
        if(aux > 0){
            atras.interactable = true;
        }
        if(aux <= 3){
            adelante.interactable = true;
        }
    }
    public void SetPlayerTexture(){
        Debug.Log(textures[aux].name);
        
        playerMaterial.SetTexture("_MainTex",textures[aux]);
    }
    public void Comprar(Button boton){
        
        int costoSkin = Convert.ToInt32(boton.gameObject.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text);
        
        Debug.Log(boton.gameObject.transform.parent.name);
        if(costoSkin <= coins){
            coins -= costoSkin;
            textCoin.SetText("Coins: " + coins);
            
            Texture tex = playerMaterial.GetTexture("_MainTex");
            actual_skin = tex.name;
            playerList.Add(boton.name);
    
            boton.gameObject.SetActive(false);
        }
        
    }
    
    public void Salir(){
        player.skins =  playerList;
        player.coins = coins;
        player.actual_skin = actual_skin;
        for(int i = 0 ; i < textures.Length ; i++){
            if(textures[i].name == actual_skin){
                playerMaterial.SetTexture("_MainTex", textures[i]);
            }
        }
        itemData = JsonMapper.ToJson(player);
        
        File.WriteAllText(Application.persistentDataPath + "/PlayerStats.json",itemData.ToString());
        string jsonString = File.ReadAllText(Application.persistentDataPath + "/PlayerStats.json");
        Debug.Log(jsonString);
        playerList.Clear();
    }
}
    
public class Player{
    public string actual_skin;
    public int coins;
    public List<string> skins = new List<string>();
    public Player(string actual_skin, int coins, List<string> skins) { 
        this.actual_skin = actual_skin;
        this.coins = coins;
        this.skins = skins;
    }
}
