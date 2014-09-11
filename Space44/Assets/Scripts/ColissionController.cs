using UnityEngine;
using System.Collections;

public class ColissionController : MonoBehaviour {
	public Transform explosion;
	private DamageController damageController;
	// Use this for initialization
	void Start () {
		damageController = GameObject.FindObjectOfType<DamageController>();

	}
	
	void OnParticleCollision(GameObject other) {
		if (this.gameObject.collider.enabled) {
			damageController.AplyDamage (other.tag, this.gameObject);
		}


	}
	void OnCollisionEnter (Collision collision){


		if (!collision.gameObject.CompareTag ("Limit")) {
			Destroy (this.gameObject);
			Instantiate (explosion, gameObject.transform.position, Quaternion.identity);
		
			Destroy (collision.gameObject);
			Instantiate (explosion, collision.gameObject.transform.position, Quaternion.identity);
		}
	}
}
