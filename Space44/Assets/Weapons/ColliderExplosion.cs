﻿using UnityEngine;
using System.Collections;

public class ColliderExplosion : MonoBehaviour {
	public float Dmg;



	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void setDmg(float dmg){
		Dmg = dmg;

	}
	void OnTriggerEnter(Collider c){
		Debug.Log (c.name);
			c.SendMessageUpwards("AplyDamage",Dmg);
			

	}
}
