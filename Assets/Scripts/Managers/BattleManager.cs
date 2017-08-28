using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class BattleManager : MonoBehaviour{

	public BattleState battleState = BattleState.playerAction;
	public PlayerAction playerAction = PlayerAction.deciding;
	public List<ComboStr> playerCombo = new List<ComboStr>();
	public int numOfEnemies = 0;
	
	// UI Elements
	private CanvasGroup OptionCanvas;
	private CanvasGroup ComboCanvas; //Also the panel for the ComboCommands

	private GameObject comboCommand;
	
	private Button FirstButton;
	private Button SecondButton;
	private Button ThirdButton;
	private Button FourthButton;

	public GameObject comboBar;

	private void Awake(){
		OptionCanvas = GameObject.Find("Options Canvas").GetComponent<CanvasGroup>();
		ComboCanvas = GameObject.Find("Combo Canvas").GetComponent<CanvasGroup>();
		FirstButton = GameObject.Find("First Button").GetComponent<Button>();
		FirstButton.onClick.AddListener(ActivateComboBar);
		SecondButton = GameObject.Find("Second Button").GetComponent<Button>();
		ThirdButton = GameObject.Find("Third Button").GetComponent<Button>();
		FourthButton = GameObject.Find("Fourth Button").GetComponent<Button>();
	}

	// Use this for initialization
	void Start (){
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
			HandlePlayerAction();
		}else if (battleState == BattleState.enemyAction){
			
		}else if (battleState == BattleState.resolveTurn){
			
		}
	}

	void HandlePlayerAction(){
		if (playerAction == PlayerAction.deciding){
			
		}else if (playerAction == PlayerAction.targeting){
			
		}else if (playerAction == PlayerAction.combo){
			//Pressing back will cancel combo commmands
			//or return player to options menu
			if (Input.GetButtonDown(ControlConst.BUTTON_B)){
				if (playerCombo.Count != 0){
					RemoveComboStr();
				}
				else{
					DeactivateComboBar();
				}
			}
			//Up inputs High Command
			if (Input.GetButtonDown(ControlConst.DPAD_UP)){
				AddComboStr(ComboStr.high);
			}
			//Right inputs Mid Command
			if (Input.GetButtonDown(ControlConst.DPAD_RIGHT)){
				AddComboStr(ComboStr.mid);
			}
			//Down inputs Low Command
			if (Input.GetButtonDown(ControlConst.DPAD_DOWN)){
				AddComboStr(ComboStr.low);
			}
		}
		else if (playerAction == PlayerAction.skill){ }
		else if (playerAction == PlayerAction.items){ }
		else if (playerAction == PlayerAction.run){ }
	}
	
	void SwitchState(int state){
		battleState = (BattleState) state;
	}

	void SwitchMenus(CanvasGroup currentCanvas, CanvasGroup targetCanvas){
		UIUtils.hideCanvas(currentCanvas);
		UIUtils.showCanvas(targetCanvas);

	}
	
	void ActivateComboBar(){
		SwitchMenus(OptionCanvas, ComboCanvas);
		playerAction = PlayerAction.combo;
	}

	void DeactivateComboBar(){
		SwitchMenus(ComboCanvas, OptionCanvas);
		playerAction = PlayerAction.deciding;
	}
	
	void AddComboStr(ComboStr comboStr){
		if (playerCombo.Count != GameManager.instance.maxCombo){
			playerCombo.Add(comboStr);
			AddCommandUI(comboStr.ToString().Substring(0,1).ToUpper());
		}
	}

	void RemoveComboStr(){
		playerCombo.RemoveAt(playerCombo.Count-1);
		RemoveCommandUI();
	}

	void AddCommandUI(String command){
		GameObject commandBar = Instantiate(comboBar, new Vector3(0, 0, 0), Quaternion.identity);
		commandBar.transform.SetParent(ComboCanvas.transform);
		commandBar.transform.GetChild(0).GetComponent<Text>().text = command;
	}

	void RemoveCommandUI(){
		Destroy(ComboCanvas.transform.GetChild(ComboCanvas.transform.childCount - 1).gameObject);
	}
	
	//Button Getters
	public void AddButtonAction(int button, UnityAction action){
		if (button == 0){
			FirstButton.onClick.AddListener(action);
		}else if (button == 1){
			SecondButton.onClick.AddListener(action);
		}else if (button == 2){
			ThirdButton.onClick.AddListener(action);
		}else if (button == 3){
			FourthButton.onClick.AddListener(action);
		}else{
			Debug.Log("Not a valid button.");
		}
	}
}
