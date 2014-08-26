using UnityEngine;
using System.Collections;

public class IAFollower : MonoBehaviour {
	public float Speed;
	 public GameObject Target;
	Vector3 destiny;
	float  cooldown = 0;
	public ParticleSystem Tiro;


	// Use this for initialization
	void Start () {
		Speed = 0.1f;


	}
	
	// Update is called once per frame
	void Update () {

		destiny = Target.transform.position;

		cooldown -= Time.deltaTime;
		if (cooldown <0) {
			Tiro.Emit (1);
			cooldown =0.5f;
		}



		if (transform.position.z > destiny.z + 4) {
						transform.LookAt (destiny);
						transform.Translate (new Vector3 (0, 0, Speed));

				} else {
			transform.Translate (new Vector3 (0, 0, Speed));
				
		}

	
	}
}
