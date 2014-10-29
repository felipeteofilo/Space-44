using UnityEngine;
using System.Collections;

public class PlayerDefenseWeapons : MonoBehaviour {
	private Status status;
	private float nextFire;
	public ParticleSystem shootM;
	public ParticleSystem shootR;
	public ParticleSystem shootL;
	public GameObject ShockWave;
	
	private int inUse =0;

	
	public float timeReload;
	public float timer;
	

	
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

				else if(status.bullets ==2){
					nextFire = Time.time + status.fireRate;
					shootR.Emit(1);
					shootL.Emit(1);
					shootAudio.Play();
					
				}
				else if(status.bullets ==3){
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
		if (Input.GetButton("Fire2")&& inUse != 1){ 
			inUse = 2;
		    if( status.actualSpecificTime < status.timeSpecific) {
			if(!ShockWave.activeSelf){
				collider.isTrigger = true;
				ShockWave.SetActive(true);
				status.actualSpecificTime +=1;
				timeReload = Time.time +status.rechargeSpecific;
			}
			}
		}else{
			inUse = 0;
		}
			if(!ShockWave.activeSelf){
				collider.isTrigger = false;
			}else{
				collider.isTrigger = true;
				ShockWave.SendMessage("setdmg",status.damageSpecific);
				ShockWave.transform.rotation = Quaternion.Euler(new Vector3(0,0,0));
				ShockWave.transform.localPosition = new Vector3(0,0.3079902f,0);

		}
		if(Time.time > timeReload){
			if(status.actualSpecificTime > 0){
			
				status.actualSpecificTime -=1;
				timeReload = Time.time +status.rechargeSpecific;
				
			}
			
		}
		
	}
	}
