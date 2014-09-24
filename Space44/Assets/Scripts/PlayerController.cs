using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary
{
	public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour {
	
	private Status status;
	public float estabilidade;
	public float tilt;
	public Boundary boundary;
	public ParticleSystem shoot;
	public ParticleSystem laser;
	public GameObject shield;

	public Vector3 buffervec;

	private float timeReload;
	private float timeReloadShield;

	private Vector3 movement;




	private float initTimeLaser;
	private float initTimeShield;

	public enum shootSelected{shoot,laser};
	public shootSelected selected = shootSelected.shoot;

	private AudioSource shootAudio;
	private AudioSource laserAudio;
	private AudioSource shieldAudio;

	private float nextFire;

	
	// Use this for initialization
	void Start () {

		rigidbody.drag = estabilidade;
		shield.renderer.material.color = new Color(shield.renderer.material.color.r,shield.renderer.material.color.g,shield.renderer.material.color.b,0.25f );

		status = this.GetComponent<Status> ();
		AudioSource[] audios = GetComponents<AudioSource>();
		shootAudio = audios[0];
		laserAudio = audios[1];
		shieldAudio = audios[2];

	}
	
	void FixedUpdate(){

		rigidbody.AddForce( movement);


		rigidbody.position = new Vector3
			(
				Mathf.Clamp (rigidbody.position.x, boundary.xMin, boundary.xMax), 
				0.0f, 
				Mathf.Clamp (rigidbody.position.z, boundary.zMin, boundary.zMax)
				);
		
		rigidbody.rotation = Quaternion.Euler (0.0f, 0.0f, rigidbody.velocity.x * -tilt);
	}
	
	// Update is called once per frame
	void Update () {

		float moveHorizontal =Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");
		
		movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		movement = movement * status.speed;

		if (Input.GetKeyDown(KeyCode.Alpha1)) {
			selected = shootSelected.shoot;
		}

		if (Input.GetKeyDown(KeyCode.Alpha2)) {
			selected = shootSelected.laser;
		}

		if (Input.GetKeyDown(KeyCode.Q)) {
			if(!shield.renderer.enabled && status.actualShieldTime < status.timeShield ){
				shield.renderer.enabled = true;
				shield.collider.enabled = true;
				this.gameObject.collider.enabled = false;
				initTimeShield = Time.time;
				shieldAudio.Play();
			}
			else{
				shieldAudio.Play();
				shield.renderer.enabled = false;
				this.gameObject.collider.enabled = true;
				initTimeShield = 0;
				timeReloadShield = Time.time + status.actualShieldTime;

			}
		}

		if (status.actualShieldTime < status.timeShield && shield.renderer.enabled) {
			if (initTimeShield != 0) {
				status.actualShieldTime += Time.time - initTimeShield;
			}
			initTimeShield = Time.time;
		} 	
		else if(shield.renderer.enabled) {
			shield.renderer.enabled = false;
			shield.collider.enabled = false;
			this.gameObject.collider.enabled = true;
			initTimeShield= 0;
			shieldAudio.Play();
		}



		if (selected == shootSelected.shoot && Input.GetButton("Fire1") && Time.time > nextFire) {
			nextFire = Time.time + status.fireRate;
			shoot.Emit(1);
			shootAudio.Play();

		}
		if (selected == shootSelected.laser && Input.GetButton("Fire1")  && status.actualLaserTime < status.timeLaser) {
			if(initTimeLaser != 0){
				status.actualLaserTime += Time.time - initTimeLaser;
			}

			initTimeLaser = Time.time;
			if(!laserAudio.isPlaying){
				laserAudio.Play();
			}

			laser.enableEmission =true;
		} else if(laser.enableEmission) {
			initTimeLaser = 0;
			laserAudio.Stop();
			timeReload = Time.time + status.actualLaserTime;
			laser.enableEmission = false;
		}
		if(!laser.enableEmission && Time.time > timeReload ){
			timeReload = Time.time + status.actualLaserTime;
			status.actualLaserTime -= status.rechargeLaser;
			if(status.actualLaserTime < 0){
				status.actualLaserTime = 0;
			}

		}
		if(!shield.renderer.enabled && Time.time > timeReloadShield ){
			timeReloadShield = Time.time + status.actualShieldTime;
			status.actualShieldTime -= status.rechargeShield;
			if(status.actualShieldTime < 0){
				status.actualShieldTime = 0;
			}
			
		}
		//Debug.Log(passedTimeShield);

	}
}
