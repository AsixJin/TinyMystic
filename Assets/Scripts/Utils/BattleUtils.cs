using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleUtils : MonoBehaviour {

	public static bool battleCheck(){
		int num = Random.Range(1, 101);
		int checkNum = num % 5;
		if (checkNum != 0){
			return false;
		}
		else{
			return true;
		}
	}
	
}
