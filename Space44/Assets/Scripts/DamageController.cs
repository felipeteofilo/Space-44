using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class Shooot{
	public string name;
	public float damage;
}

public class DamageController : MonoBehaviour {

	public List <Shooot> shootList = new List<Shooot>();
	public TextAsset shootsReference; 

	void Start () {

		string[] shoots = shootsReference.text.Split('\n');

		for (int i = 0; i < shoots.Length; i++) {
			string [] shootStatus = shoots[i].Split('=');

			Shooot shoot = new Shooot();
			shoot.name = shootStatus[0].Trim();
			shoot.damage = float.Parse(shootStatus[1]);
			shootList.Add(shoot);
		}
		shootList[0].damage *=GameObject.FindGameObjectWithTag("Player").GetComponent<Status>().damage*
			GameObject.FindGameObjectWithTag("Player").GetComponent<Status>().lvlDamage;
	}

	// Update is called once per frame
	void Update () {
	
	}

	public void AplyDamage(string typeOfShoot, GameObject hitObject){

		Shooot hitShoot = new Shooot ();
		for (int i = 0; i<shootList.Count; i++) {

			if(shootList[i].name == typeOfShoot){
				hitShoot = shootList[i];
			}
		}
		if(hitObject.tag == "Player" && !hitShoot.name.Contains("Player")){

			hitObject.GetComponent<Status>().life  =hitObject.GetComponent<Status>().life - hitShoot.damage;

		}


		if(hitObject.tag == "Enemy" && !hitShoot.name.Contains("Enemy")){
			hitObject.GetComponent<EnemyStatus>().life  -=  hitShoot.damage;



		}

	}
}
