using UnityEngine;
using System.Collections;

public class PlayerDefenseWeapons : MonoBehaviour {
	private Status status;
	private float nextFire;
	public ParticleSystem shoot;
	public GameObject ShockWave;
	
	

	
	public float timeReload;
	public float timer;
	
	public enum shootSelected{shoot,shock};
	public shootSelected selected = shootSelected.shoot;
	
	private AudioSource shootAudio;
	
	
	// Use this for initialization
	void Start () {
		
		status = this.GetComponent<Status> ();
		AudioSource[] audios = GetComponents<AudioSource>();
		shootAudio = audios[0];

		
	}
	
	// Update is called once per frame
	void Update () {

		ShockWave.transform.rotation = Quaternion.Euler(new Vector3(0,0,0));
		ShockWave.transform.localPosition = new Vector3(0,0.3079902f,0);
		if (Input.GetKeyDown(KeyCode.Alpha1)) {
			selected = shootSelected.shoot;
		}
		
		if (Input.GetKeyDown(KeyCode.Alpha2)) {
			selected = shootSelected.shock;
		}
		
		if (selected == shootSelected.shoot && Input.GetButton("Fire1") && Time.time > nextFire) {
			nextFire = Time.time + status.fireRate;
			shoot.Emit(1);
			shootAudio.Play();
			
		}
		if (selected == shootSelected.shock && Input.GetButton("Fire1")  
		    && status.actualSpecificTime < status.timeSpecific) {
			if(!ShockWave.activeSelf){
				ShockWave.SetActive(true);
				status.actualSpecificTime +=1;
				timeReload = Time.time +status.rechargeSpecific;
			}
		}
			if(!ShockWave.activeSelf){
				collider.isTrigger = false;
			}else{
				collider.isTrigger = true;
				ShockWave.SendMessage("setdmg",status.damageSpecific);

		}
		if(Time.time > timeReload){
			if(status.actualSpecificTime > 0){
					Debug.Log("Caiu");
				status.actualSpecificTime -=1;
				timeReload = Time.time +status.rechargeSpecific;
				
			}
			
		}
		
	}
	}
