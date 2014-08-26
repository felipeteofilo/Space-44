using UnityEngine;
using System.Collections;

public class IAenemy : MonoBehaviour {

	public float Speed;
	public GameObject Target;
	Vector3 destiny;
	public ParticleSystem Tiro;
	float cooldown = 0;

	// Use this for initialization
	void Start () {

		Speed = 0.1f;
		destiny = Target.transform.position;
		transform.LookAt (destiny);

	
	}
	
	// Update is called once per frame
	void Update () {

		transform.Translate (new Vector3 (0, 0, Speed));


		cooldown -= Time.deltaTime;
		if (cooldown <0) {
						Tiro.Emit (1);
			cooldown =0.5f;
				}
	


	}
}
