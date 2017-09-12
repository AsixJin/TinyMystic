using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectCanvas : MonoBehaviour{

	private bool isInit = false;
	
	public CanvasGroup mCanvasGroup;
	public Text currentText;
	
	List<BattleStats> selectionGroup = new List<BattleStats>();
	private int index = 0;

	private void Awake(){
		
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (isInit){
			//selectionGroup[index].GetComponent<SpriteRenderer>().color;		
		}
	}
	
	//Init a new list
	public void initSelection(List<BattleStats> group){
		selectionGroup = group;
		index = 0;
		currentText.text = selectionGroup[index].targetName;
		isInit = true;

	}

	public void cycleForward(){
		if (index < selectionGroup.Count - 1){
			index++;
		}
		currentText.text = selectionGroup[index].targetName;
	}
	
	public void cycleBack(){
		if (index != 0){
			index--;
		}
		currentText.text = selectionGroup[index].targetName;
	}

	public BattleStats getSelection(){
		return selectionGroup[index];
	}
	
	//Returns the canvas group
	public CanvasGroup GetCanvasGroup(){
		return mCanvasGroup;
	}
}
