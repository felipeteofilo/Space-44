﻿using UnityEngine;
using System.Collections;

public class HUDscript : MonoBehaviour {
	private Status status;

	float MaxLife;
public	float CurrentLife;
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
		GUI.TextArea(new Rect(0.86f*width,0,0.13f*width,20),"Life");
		GUI.Box(new Rect(0.86f*width,20,0.13f*width,20),""+(int)CurrentLife);
		GUI.Box(new Rect(0.86f*width,20,(0.13f*width)/(MaxLife/CurrentLife),20),"");
		//Laser
		GUI.TextArea(new Rect(0.86f*width,45,0.13f*width,20),"Special");
		GUI.Box(new Rect(0.86f*width,65,0.13f*width,20),""+(int)CurrentSpecial);
		GUI.Box(new Rect(0.86f*width,65,(0.13f*width)/(MaxSpecial/CurrentSpecial),20),"");
		//Escudo
		GUI.TextArea(new Rect(0.86f*width,90,0.13f*width,20),"Shield");
		GUI.Box(new Rect(0.86f*width,110,0.13f*width,20),""+(int)CurrentShield);
		GUI.Box(new Rect(0.86f*width,110,(0.13f*width)/(MaxShield/CurrentShield),20),"");
		
		GUI.Box(new Rect(0.86f*width,150,0.13f*width,20),"Time: "+(int)(Time.timeSinceLevelLoad/60)+":"+(int)(Time.timeSinceLevelLoad%60));

		
		
	}
}
