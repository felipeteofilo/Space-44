using UnityEngine;
using System.Collections;

public class PlayerStabilityWeapons : MonoBehaviour {
	
	private Status status;
	private float nextFire;
	public ParticleSystem shoot;
	public GameObject Missel;
	public GameObject SMissel;
	private float MisselRate = 1f;
	private float nextMissel;
	
	
	
	
	private float timeReload;
	
	
	public enum shootSelected{shoot,bomb};
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
		if (Input.GetKeyDown(KeyCode.Alpha1)) {
			selected = shootSelected.shoot;
		}
		
		if (Input.GetKeyDown(KeyCode.Alpha2)) {
			selected = shootSelected.bomb;
		}
		
		if (selected == shootSelected.shoot && Input.GetButton("Fire1") && Time.time > nextFire) {
			nextFire = Time.time + status.fireRate;
			shoot.Emit(1);
			shootAudio.Play();
			
		}
		if (selected == shootSelected.bomb && Input.GetButton("Fire1")  
		    && status.actualSpecificTime < status.timeSpecific) {
			if(Time.time > nextMissel){
				Instantiate(Missel,SMissel.transform.position,SMissel.transform.rotation);
				status.actualSpecificTime +=1;
				nextMissel = Time.time + MisselRate;
				timeReload = Time.time +status.rechargeSpecific;
			}
		}
		if(Time.time > timeReload){
			if(status.actualSpecificTime > 0){
				status.actualSpecificTime -=1;
				timeReload = Time.time +status.rechargeSpecific;
				
			}
			
		}
		
	}
}