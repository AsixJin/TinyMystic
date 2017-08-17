using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleManager : MonoBehaviour{

	public static BattleManager instance;

	public BattleState battleState = BattleState.playerAction;
	public int numOfEnemies = 0;
	
	// UI Elements
	public Button FirstButton;
	public Button secondButton;
	public Button thirdButton;
	public Button fourthButton;

	private void Awake(){
		instance = this;
	}

	// Use this for initialization
	void Start () {
		PositionEnemies();
	}
	
	// Update is called once per frame
	void Update () {
		HandleState();
	}

	void PositionEnemies(){
		numOfEnemies = GameManager.instance.enemyGroup.Count;
		String positionPrefab = "Markers/EnemyGroup" + numOfEnemies;
		GameObject positionMarkers = Resources.Load(positionPrefab, typeof(GameObject)) as GameObject;
		Instantiate(positionMarkers);
		for (int i = 0; i < numOfEnemies; i++){
			GameObject marker = GameObject.Find("Marker" + (i+1));
			GameObject enemy = GameManager.instance.enemyGroup[i].gameObject; 
			Instantiate(enemy, marker.transform.position, Quaternion.identity);
		}
	}

	void HandleState(){
		if (battleState == BattleState.playerAction){
			
		}else if (battleState == BattleState.enemyAction){
			
		}else if (battleState == BattleState.resolveTurn){
			
		}
	}

	void SwitchState(int state){
		battleState = (BattleState) state;
	}
}
