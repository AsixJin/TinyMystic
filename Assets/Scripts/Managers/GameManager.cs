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
	public String currentScene;
	public Vector3 playerPosition;
	
	//Player Information
	public GameObject playerObject;
	public BattleStats playerStats;
	
	//Battle Related
	public bool inBattle = false;
	public BattleManager battleManager;
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
	void Start (){
		
	}

	private void OnDisable(){
		SceneManager.sceneLoaded -= loadedScene;
	}

	private void OnEnable(){
		SceneManager.sceneLoaded += loadedScene;
	}

	// Update is called once per frame
	void Update (){
		GameUpdate();
	}

	void GameUpdate(){
		gameTimer += Time.deltaTime;
		if(!inBattle)
			playerPosition = playerObject.GetComponent<Transform>().position;
	}
	
	public void startBattle(List<BattleStats> enemies){
		enemyGroup = enemies;
		SceneManager.LoadScene("BattleScene");
		inBattle = true;
	}

	public void endBattle(){
		inBattle = false;
		SceneManager.LoadScene(currentScene);
		playerObject.transform.position = playerPosition;
	}

	void loadedScene(Scene scene, LoadSceneMode mode){
		playerObject = GameObject.Find("Player");
		if (scene.name == "BattleScene"){
			SetupBattleScene();
		}else{
			currentScene = SceneManager.GetActiveScene().name;
			playerObject.transform.position = playerPosition;
		}
		
	}

	void SetupBattleScene(){
		battleManager = GameObject.Find("BManager").GetComponent<BattleManager>();
		battleManager.FourthButton.onClick.AddListener(endBattle);
	}
	
	
}
