﻿using UnityEngine;
using System.Collections;

public class PlayerStabilityWeapons : MonoBehaviour {
	
	private Status status;
	private float nextFire;
	public ParticleSystem shootM;
	public ParticleSystem shootR;
	public ParticleSystem shootL;
	public GameObject Missel;
	public GameObject SMissel;
	private float MisselRate = 1f;
	private float nextMissel;
	public int inUse =0;
	
	
	
	private float timeReload;
	
	

	
	private AudioSource shootAudio;
	
	
	// Use this for initialization
	void Start () {
		
		status = this.GetComponent<Status> ();
		AudioSource[] audios = GetComponents<AudioSource>();
		shootAudio = audios[0];
		
		
		
	}
	
	// Update is called once per frame
	void Update () {
	
		
		if ( Input.GetButton("Fire1")&& inUse != 2){ 
			
			inUse = 1;
			if( Time.time > nextFire  ) {
				if(status.bullets ==1){
					nextFire = Time.time + status.fireRate;
					shootM.Emit(1);
					shootAudio.Play();
				}
				
				if(status.bullets ==2){
					nextFire = Time.time + status.fireRate;
					shootR.Emit(1);
					shootL.Emit(1);
					shootAudio.Play();
					
				}
				if(status.bullets ==3){
					nextFire = Time.time + status.fireRate;
					shootR.Emit(1);
					shootM.Emit(1);
					shootL.Emit(1);
					
					shootAudio.Play();
					
				}
			}
		}else{
			inUse = 0;
		}

		if ( Input.GetButton("Fire2")&& inUse != 1) {
			inUse =2;
		    if( status.actualSpecificTime < status.timeSpecific) {
			if(Time.time > nextMissel){
				Instantiate(Missel,SMissel.transform.position,SMissel.transform.rotation);
				status.actualSpecificTime +=1;
				nextMissel = Time.time + MisselRate;
				timeReload = Time.time +status.rechargeSpecific;
			}
		}
		}else{
			inUse = 0;
		}
		if(Time.time > timeReload){
			if(status.actualSpecificTime > 0){
				status.actualSpecificTime -=1;
				timeReload = Time.time +status.rechargeSpecific;
				
			}
			
		}
		
	}
}