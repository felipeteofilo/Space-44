using UnityEngine;
using System.Collections;

public class PlayerPowerWeapons : MonoBehaviour {

	private Status status;
	private float nextFire;
	public ParticleSystem shoot;
	public GameObject Bomb;
	public GameObject SBomb;
	private float BombRate = 1.3f;
	private float nextBomb;




	private float timeReload;
	
	private int inUse=0;

	
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
			nextFire = Time.time + status.fireRate;
			shoot.Emit(1);
			shootAudio.Play();
			
			}
		}else{
			inUse = 0;
		}

		if ( Input.GetButton("Fire2") && inUse != 1){ 
			inUse = 2;
		    if( status.actualSpecificTime < status.timeSpecific ) {
			if(Time.time > nextBomb){
			Instantiate(Bomb,SBomb.transform.position,SBomb.transform.rotation);
			status.actualSpecificTime +=1;
			nextBomb = Time.time + BombRate;
			timeReload = Time.time +status.rechargeSpecific;
				}
			}
			}else{
				inUse =0;
			}


		if(Time.time > timeReload){
			if(status.actualSpecificTime > 0){
				status.actualSpecificTime -=1;
				timeReload = Time.time +status.rechargeSpecific;

			}

		}
			
	}
}
		
	
