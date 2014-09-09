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
		damageController.AplyDamage (other.tag, this.gameObject);


	}
	void OnCollisionEnter (Collision collision){
		if (!this.gameObject.CompareTag("Asteroid")) {
			Destroy (this.gameObject);
			Object exp = Instantiate (explosion, gameObject.transform.position, Quaternion.identity);
		}
		Destroy (collision.gameObject);
		Object exp1 = Instantiate(explosion, collision.gameObject.transform.position, Quaternion.identity);
	}
}
