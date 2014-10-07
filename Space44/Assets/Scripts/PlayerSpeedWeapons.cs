using UnityEngine;
using System.Collections;

public class PlayerSpeedWeapons : MonoBehaviour {
	private Status status;
	private float nextFire;
	public ParticleSystem shoot;
	public ParticleSystem laser;


	private float initTimeLaser;


	private float timeReload;


	public enum shootSelected{shoot,laser};
	public shootSelected selected = shootSelected.shoot;
	
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
		if (Input.GetKeyDown(KeyCode.Alpha1)) {
			selected = shootSelected.shoot;
		}
		
		if (Input.GetKeyDown(KeyCode.Alpha2)) {
			selected = shootSelected.laser;
		}

		if (selected == shootSelected.shoot && Input.GetButton("Fire1") && Time.time > nextFire) {
			nextFire = Time.time + status.fireRate;
			shoot.Emit(1);
			shootAudio.Play();
			
		}
		if (selected == shootSelected.laser && Input.GetButton("Fire1")  && status.actualSpecificTime < status.timeSpecific) {
			if(initTimeLaser != 0){
				status.actualSpecificTime += Time.time - initTimeLaser;
			}
			
			initTimeLaser = Time.time;
			if(!laserAudio.isPlaying){
				laserAudio.Play();
			}
			
			laser.enableEmission =true;
		} else if(laser.enableEmission) {
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
