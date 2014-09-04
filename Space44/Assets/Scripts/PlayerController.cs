using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary
{
	public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour {
	
	public float speed;
	public float tilt;
	public Boundary boundary;
	public ParticleSystem shoot;
	public ParticleSystem laser;

	public Vector3 buffervec;
	public float timeLaser;
	public float timeReload;


	private float passedTimeLaser;

	private float initTimeLaser;

	public enum shootSelected{shoot,laser};
	public shootSelected selected = shootSelected.shoot;

	private float nextFire;
	public float fireRate;
	
	// Use this for initialization
	void Start () {
		//initTimeLaser = 0;
	}
	
	void FixedUpdate(){
		float moveHorizontal =Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");
		
		buffervec = new Vector3 (moveHorizontal, 0.0f, moveVertical);
//
//		rigidbody.velocity = buffervec * speed;

		rigidbody.velocity = Vector3.ClampMagnitude (rigidbody.velocity, speed);

		
		rigidbody.position = new Vector3
			(
				Mathf.Clamp(rigidbody.position.x, boundary.xMin, boundary.xMax),
				0.0f,
				Mathf.Clamp(rigidbody.position.z, boundary.zMin, boundary.zMax)
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

		if (selected == shootSelected.shoot && Input.GetButton ("Fire1") && Time.time > nextFire) {
			nextFire = Time.time + fireRate;
			shoot.Emit(1);
		}
		if (selected == shootSelected.laser && Input.GetButton ("Fire1") && passedTimeLaser < timeLaser) {
			if(initTimeLaser != 0){
				passedTimeLaser += Time.time - initTimeLaser;
			}

			initTimeLaser = Time.time;

			laser.enableEmission = true;
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
		Debug.Log(passedTimeLaser);

	}
}
