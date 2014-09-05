using UnityEngine;
using System.Collections;

public class ColissionController : MonoBehaviour {

	private DamageController damageController;
	// Use this for initialization
	void Start () {
		damageController = GameObject.FindObjectOfType<DamageController>();
	}
	
	void OnParticleCollision(GameObject other) {

		damageController.AplyDamage (other.tag, this.gameObject);

	}
	void OnCollisionEnter (Collision collision){

		//Destroy (this.gameObject, 1.0f);
		//Destroy (collision.gameObject, 1.0f);
	}
}
