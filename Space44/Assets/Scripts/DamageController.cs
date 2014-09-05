using UnityEngine;
using System.Collections;

[System.Serializable]
public class Shooot{
	public string name;
	public float damage;
}

public class DamageController : MonoBehaviour {

	public ArrayList dmg1 = new ArrayList();
	public enum dmg{Default,BasicShoot,PlayerLaser,EnemyBasicShoot,Enemy,BossShoot,BossLaser,BossBomb,Boss,Asteroid};
	public dmg DMG = dmg.Default;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void AplyDamage(string typeOfShoot){
	
		dmg1.

	}
}
