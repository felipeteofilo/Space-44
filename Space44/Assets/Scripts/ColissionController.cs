using UnityEngine;
using System.Collections;

public class ColissionController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	void OnParticleCollision(GameObject other) {

		if (other.tag == "TiroBasico"){
			Destroy (this.gameObject);
		}
		if (other.tag == "TiroBasicoInimigo" && this.tag == "Player"){
			Destroy (this.gameObject);
		}
		
	}
	void OnCollisionEnter (Collision collision){

		//Destroy (this.gameObject);
		//Destroy (collision.gameObject);
	}
}
