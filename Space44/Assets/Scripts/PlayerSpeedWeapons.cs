using UnityEngine;
using System.Collections;

public class PlayerSpeedWeapons : MonoBehaviour {
	private Status status;
	private float nextFire;
	public ParticleSystem shootM;
	public ParticleSystem shootL;
	public ParticleSystem shootR;
	public ParticleSystem laser;
	private int inUse =0;

	private float initTimeLaser;


	private float timeReload;



	
	private AudioSource shootAudio;
	private AudioSource laserAudio;

	// Use this for initialization
	void Start () {

		status = this.GetComponent<Status> ();
		AudioSource[] audios = GetComponents<AudioSource>();
		shootAudio = audios[0];
		laserAudio = audios[2];

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

		if (  Input.GetButton("Fire2") && inUse !=1  
		    && status.actualSpecificTime < status.timeSpecific) {
			inUse =2;
			if(initTimeLaser != 0){
				status.actualSpecificTime += Time.time - initTimeLaser;
			}
			
			initTimeLaser = Time.time;
			if(!laserAudio.isPlaying){
				laserAudio.Play();
			}
			
			laser.enableEmission =true;
		} else if(laser.enableEmission) {
			inUse = 0;
			initTimeLaser = 0;
			laserAudio.Stop();
			timeReload = Time.time + status.actualSpecificTime;
			laser.enableEmission = false;
		}
		if(!laser.enableEmission && Time.time > timeReload ){
			timeReload = Time.time + status.actualSpecificTime;
			status.actualSpecificTime -= status.rechargeSpecific;
			if(status.actualSpecificTime < 0){
				status.actualSpecificTime = 0;
			}
			
		}

	}
}
