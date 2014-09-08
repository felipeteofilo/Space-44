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
			destroyParticlesByTime();
			Destroy(this.gameObject);
		}

	
	}
	void destroyParticlesByTime()
	{
		ParticleSystem particle;
		particle = this.gameObject.GetComponentInChildren<ParticleSystem>();

		particle.Stop ();

		particle.transform.parent = null;

		GameObject.Destroy(particle.gameObject,particle.duration);
	}
}
