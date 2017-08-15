using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour{

	public int numOfEnemies = 0;
	
	
	// Use this for initialization
	void Start () {
		PositionEnemies();
	}
	
	// Update is called once per frame
	void Update () {
		
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
}
