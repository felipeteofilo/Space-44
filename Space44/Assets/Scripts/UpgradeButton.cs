using UnityEngine;
using System.Collections;

public class UpgradeButton : MonoBehaviour {


	public SaveScript statusToUpgrade;
	public int ID;
	public float Price;
	GlobalStatus global;

	// Use this for initialization
	void Start () {
		global = GameObject.FindGameObjectWithTag ("Global").GetComponent<GlobalStatus> ();
		Price = Price * (global.status.levelButtons [ID] + 1);
	}
	

	public void Buy(){
		global.status.BonusRate += statusToUpgrade.BonusRate;
		global.status.BonusLife += statusToUpgrade.BonusLife;
		global.status.BonusSpeed += statusToUpgrade.BonusSpeed;
		global.status.BonusStability += statusToUpgrade.BonusStability;
		global.status.BonusSpecific += statusToUpgrade.BonusSpecific;
		global.status.BonusShield += statusToUpgrade.BonusShield;
		global.status.bullets += statusToUpgrade.bullets;

		global.status.lvlDamage += statusToUpgrade.lvlDamage;



		global.status.levelButtons [ID] += 1;
		Price = Price * (global.status.levelButtons [ID] + 1);

	}
}
