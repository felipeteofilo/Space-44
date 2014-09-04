using UnityEngine;
using System.Collections;

public class MoveNave : MonoBehaviour {
	public float velControl;
	public float velVirada;
	public float altura;
	public Vector3 buffervec;
	public ParticleSystem jato1;
	public ParticleSystem jato2;
	public ParticleSystem tiro;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		velControl = Input.GetAxis ("Vertical");

		velVirada = Input.GetAxis ("Horizontal");


		jato1.emissionRate = velControl * 1000;
		jato2.emissionRate = velControl * 1000;
		if(Input.GetButtonDown("Fire1")){
			tiro.Emit(1);
		}
		if (Input.GetKey(KeyCode.Q)) {

			altura+=0.1f;
		}
		if (Input.GetKey(KeyCode.E)) {
			
			altura-=0.1f;
		}

		RaycastHit hit;

		if (Physics.Raycast (transform.position, new Vector3 (0, -1, 0), out hit)) {
			transform.position += new Vector3(0,(hit.distance -altura)*-1,0);
		}

		buffervec += transform.forward * velControl;
		buffervec = Vector3.ClampMagnitude (buffervec, 100);
		buffervec = Vector3.Lerp (buffervec, Vector3.zero, Time.deltaTime);

		transform.Translate(buffervec *Time.smoothDeltaTime,Space.World);
		transform.Rotate (new Vector3 (0, velVirada, 0));
	}
	void FixedUpdate(){
		if(Physics.Raycast(transform.position,buffervec,5)){
			buffervec = buffervec*-1;
		}
	}
}
