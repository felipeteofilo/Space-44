using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary
{
	public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour {
	
	private Status status;
	public float tilt;
	public Boundary boundary;
	public ParticleSystem shoot;
	public ParticleSystem laser;
	public GameObject shield;

	public Vector3 buffervec;
	public float timeLaser;
	public float timeShield;
	private float timeReload;
	private float timeReloadShield;


	private float passedTimeShield;
	private float passedTimeLaser;

	private float initTimeLaser;
	private float initTimeShield;

	public enum shootSelected{shoot,laser};
	public shootSelected selected = shootSelected.shoot;

	private float nextFire;

	
	// Use this for initialization
	void Start () {

		shield.renderer.material.color = new Color(shield.renderer.material.color.r,shield.renderer.material.color.g,shield.renderer.material.color.b,0.15f );

		status = this.GetComponent<Status> ();
	}
	
	void FixedUpdate(){
		float moveHorizontal =Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");
		
		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		rigidbody.velocity = movement * status.speed;
		
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

		if (Input.GetKeyDown(KeyCode.Alpha1)) {
			selected = shootSelected.shoot;
		}

		if (Input.GetKeyDown(KeyCode.Alpha2)) {
			selected = shootSelected.laser;
		}

		if (Input.GetKeyDown(KeyCode.Q)) {
			if(!shield.renderer.enabled && passedTimeShield < timeShield ){
				shield.renderer.enabled = true;
				shield.collider.enabled = true;
				initTimeShield = Time.time;
			}
			else{
				shield.renderer.enabled = false;
				shield.collider.enabled = false;
				initTimeShield = 0;
				timeReloadShield = Time.time + passedTimeShield;
			}
		}

		if (passedTimeShield < timeShield && shield.renderer.enabled) {
			if (initTimeShield != 0) {
				passedTimeShield += Time.time - initTimeShield;
			}
			initTimeShield = Time.time;
		} 	
		else  {
			shield.renderer.enabled = false;
			shield.collider.enabled = false;
			initTimeShield= 0;
		}



		if (selected == shootSelected.shoot && Input.GetButton ("Fire1") && Time.time > nextFire) {
			nextFire = Time.time + status.fireRate;
			shoot.Emit(1);
		}
		if (selected == shootSelected.laser && Input.GetButton ("Fire1") && passedTimeLaser < timeLaser) {
			if(initTimeLaser != 0){
				passedTimeLaser += Time.time - initTimeLaser;
			}

			initTimeLaser = Time.time;

			laser.enableEmission =true;
		} else if(laser.enableEmission) {
			initTimeLaser = 0;
			timeReload = Time.time + passedTimeLaser;
			laser.enableEmission = false;
		}
		if(!laser.enableEmission && Time.time > timeReload ){
			timeReload = Time.time + passedTimeLaser;
			passedTimeLaser -= 0.1f;
			if(passedTimeLaser < 0){
				passedTimeLaser = 0;
			}

		}
		if(!shield.renderer.enabled && Time.time > timeReloadShield ){
			timeReloadShield = Time.time + passedTimeShield;
			passedTimeShield -= 0.5f;
			if(passedTimeShield < 0){
				passedTimeShield = 0;
			}
			
		}
		//Debug.Log(passedTimeShield);

	}
}
