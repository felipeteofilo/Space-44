using UnityEngine;
using System.Collections;

public class ColissionController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	void OnParticleCollision(GameObject other) {
		Debug.Log (this.name);
		if (other.tag == "TiroBasico"){
			Destroy (this.gameObject);
		}
		if (other.tag == "TiroBasicoInimigo" && this.tag == "Player"){
			Destroy (this.gameObject);
		}
		
	}
	void OnCollisionEnter (Collision collision){
		Debug.Log ("foi");
		Destroy (this.gameObject);
		Destroy (collision.gameObject);
	}
}
