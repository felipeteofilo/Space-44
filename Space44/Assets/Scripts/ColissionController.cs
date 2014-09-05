using UnityEngine;
using System.Collections;

public class ColissionController : MonoBehaviour {

	private DamageController damageController;
	// Use this for initialization
	void Start () {
		damageController = this.gameObject.GetComponent<DamageController>();
	}
	
	void OnParticleCollision(GameObject other) {

		if (other.tag == "TiroBasico"){
			damageController.AplyDamage(0);
		}
		if (other.tag == "Laser") {
			Destroy (this.gameObject);
		}
		if (other.tag == "TiroBasicoInimigo" && this.tag == "Player"){
			Destroy (this.gameObject);
		}

	}
	void OnCollisionEnter (Collision collision){

		Destroy (this.gameObject, 1.0f);
		Destroy (collision.gameObject, 1.0f);
	}
}
