using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour{
	
	//Singleton Instance
	public static GameManager instance;

	//General Information
	public float gameTimer = 0;
	
	//Player Information
	public String playerName = "";
	public int playerLevel = 1;
	public int playerHealth = 50;
	public int playerEnergy = 10;
	
	//Battle Related
	public List<BattleStats> enemyGroup;

	private void Awake(){
		if (instance != null){
			Destroy(this.gameObject);
		}else{
			instance = this;
			DontDestroyOnLoad(this);
		}
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update (){
		gameTimer += Time.deltaTime;
	}

	public void startBattle(List<BattleStats> enemies){
		enemyGroup = enemies;
		SceneManager.LoadScene("BattleScene");
	}
}
