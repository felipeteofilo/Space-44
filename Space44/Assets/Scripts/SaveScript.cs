﻿using UnityEngine;
using System.Collections;


[System.Serializable]
public class SaveScript{


	 public int nave;
	 public int faseAtual;

	//upgrades
	 public float lvlDamage ;
	 public float BonusRate ;
	 public float BonusLife ;
	 public float BonusShield;
	 public float BonusSpecific;
	 public float BonusSpeed;
	 public float BonusStability;
	 public int bullets;

	//level Upgrades
	public int[]levelButtons = new int[8];



	//pontos
	 public float TotalPoints;
}
