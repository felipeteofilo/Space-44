using UnityEngine;
using System.Collections;

public class HUDscript : MonoBehaviour {
	private Status status;

	float MaxLife;
	float CurrentLife;
	float MaxSpecial;
	float CurrentSpecial;
	float MaxShield;
	float CurrentShield;
	
	float tester;
	float width;
	// Use this for initialization
	void Start () {
		
		width = Screen.width;

		status = GameObject.FindGameObjectWithTag ("Player").GetComponent<Status> ();
		MaxLife = status.MaxLife;
		MaxSpecial = status.timeLaser;
		MaxShield = status.timeShield;
	
	}
	
	// Update is called once per frame
	void Update () {

		CurrentLife = status.life;
		CurrentSpecial = status.actualLaserTime;
		CurrentShield = status.actualShieldTime;

		
		width = Screen.width;
		//Pegar Status do Jogador e setar nas tretas
		
	}
	void OnGUI(){
		GUI.color = Color.white;
		//Vida

		GUI.Box(new Rect(0.86f*width,10,0.13f*width,20),""+(int)CurrentLife);
		GUI.Box(new Rect(0.86f*width,10,(0.13f*width)/(MaxLife/CurrentLife),20),"");
		//Laser
		GUI.Box(new Rect(0.86f*width,35,0.13f*width,20),""+(int)CurrentSpecial);
		GUI.Box(new Rect(0.86f*width,35,(0.13f*width)/(MaxSpecial/CurrentSpecial),20),"");
		//Escudo
		GUI.Box(new Rect(0.86f*width,60,0.13f*width,20),""+(int)CurrentShield);
		GUI.Box(new Rect(0.86f*width,60,(0.13f*width)/(MaxShield/CurrentShield),20),"");
		
		
	}
}
