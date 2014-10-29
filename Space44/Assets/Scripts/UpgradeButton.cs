using UnityEngine;
using System.Collections;

public class UpgradeButton : MonoBehaviour {


	public SaveScript statusToUpgrade;
	public int ID;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void Buy(GlobalStatus global){
		global.status.BonusRate += statusToUpgrade.BonusRate;
		global.status.BonusLife += statusToUpgrade.BonusLife;
		global.status.BonusSpeed += statusToUpgrade.BonusSpeed;
		global.status.BonusStability += statusToUpgrade.BonusStability;
		global.status.BonusSpecific += statusToUpgrade.BonusSpecific;
		global.status.BonusShield += statusToUpgrade.BonusShield;
		global.status.bullets += statusToUpgrade.bullets;

		global.status.lvlDamage += statusToUpgrade.lvlDamage;

		global.status.levelButtons [ID] += 1;
	}
}
