using UnityEngine;
using System.Collections;

public class Status : MonoBehaviour {

	public float MaxLife;
	public float life;
	public float speed;
	public float stability;
	public float damage;
	public float fireRate;
	public float shieldResistence;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (life <= 0) {
			//this.gameObject.GetComponentInChildren<ParticleSystem>().GetComponent<ParticleAnimator>().autodestruct = true;
			//this.gameObject.GetComponentInChildren<ParticleSystem>().transform.parent = null;
			Destroy(this.gameObject);
		}
	
	}
}
