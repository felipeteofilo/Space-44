using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary
{
	public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour {
	
	private Status status;

	public GameObject shield;

	public float tilt;
	public Boundary boundary;
	private float initTimeShield;
	private float timeReloadShield;
	private AudioSource shieldAudio;
	public Vector3 buffervec;
	private Vector3 movement;
	public GameObject explosion;


	
	// Use this for initialization
	void Start () {
		shield.renderer.material.color = new Color(shield.renderer.material.color.r,shield.renderer.material.color.g,shield.renderer.material.color.b,0.25f );
		status = this.GetComponent<Status> ();
		rigidbody.drag = status.stability;
		AudioSource[] audios = GetComponents<AudioSource>();
		
		shieldAudio = audios[1];

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
		if(status.life <0){
			status.life =0;
		}

		float moveHorizontal =Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");
		
		movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		movement = movement * status.speed;

		if (Input.GetAxis("Jump")!= 0 && status.actualShieldTime < status.timeShield) {
						if (!shield.renderer.enabled ) {
								shield.renderer.enabled = true;
								shield.collider.enabled = true;
								this.gameObject.collider.enabled = false;
								initTimeShield = Time.time;
								shieldAudio.Play ();
						} 
				} 
		else {
				
				shield.renderer.enabled = false;
				this.gameObject.collider.enabled = true;
				initTimeShield = 0;
				timeReloadShield = Time.time + status.actualShieldTime;
				
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

		if(!shield.renderer.enabled && Time.time > timeReloadShield ){
			timeReloadShield = Time.time + status.actualShieldTime;
			status.actualShieldTime -= status.rechargeShield;
			if(status.actualShieldTime < 0){
				status.actualShieldTime = 0;
			}
			
		}

	}
	void OnCollisionEnter (Collision collision){

		if(collision.transform.tag == "Enemy"){
			SendMessage("AplyDamage",10f);
			GetComponent<ColissionController>().SendMessage("PiscaAe",0.03f);

		}
		if(collision.transform.tag == "Boss"){
			Instantiate(explosion,transform.position,transform.rotation);
			Destroy(gameObject);
		}
		if(collision.transform.tag == "Asteroid"){
			SendMessage("AplyDamage",5f);
			GetComponent<ColissionController>().SendMessage("PiscaAe",0.03f);
			Instantiate(explosion,collision.transform.position,collision.transform.rotation);
			Destroy(collision.gameObject,0.1f);
			
		}
		
		
		
	}
	void AplyDamage(float dmg){
		if (!shield.renderer.enabled) {
						status.life -= dmg;
				} else {
			status.life -= dmg/2;
		}
		if(status.life <0){
			status.life =0;
		}
	}
}
