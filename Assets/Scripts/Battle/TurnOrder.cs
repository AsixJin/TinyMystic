using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOrder{

	private BattleStats actor;
	private BattleStats target;
	private List<ComboStr> combo;

	public TurnOrder(BattleStats actor, BattleStats target, List<ComboStr> combo){
		this.actor = actor;
		this.target = target;
		this.combo = combo;
	}

	public BattleStats Actor{
		get{ return actor; }
		set{ actor = value; }
	}

	public BattleStats Target{
		get{ return target; }
		set{ target = value; }
	}

	public List<ComboStr> Combo{
		get{ return combo; }
		set{ combo = value; }
	}
}
