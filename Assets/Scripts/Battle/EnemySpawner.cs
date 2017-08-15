using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour{

    public List<BattleStats> enemies = new List<BattleStats>();
    
    private void OnTriggerStay2D(Collider2D other){
        if (BattleUtils.battleCheck()){
            generateEnemyGroup();
            Debug.Log("Battle Start");
        }
    }

    public void generateEnemyGroup(){
        int groupSize = Random.Range(1, 5);
        List<BattleStats> enemyGroup = new List<BattleStats>();
        for (int i = 0; i < groupSize; i++){
            enemyGroup.Add(enemies[Random.Range(0, enemies.Count-1)]);
        }
        GameManager.instance.startBattle(enemyGroup);
    }
    
    
    
}
