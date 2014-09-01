using UnityEngine;
using System.Collections;

public class RandomRotator : MonoBehaviour {

	public float tumble;

	// Use this for initialization
	void Start () {

		rigidbody.angularVelocity = Random.insideUnitSphere * tumble;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnParticleCollision(GameObject other) {

		if (other.tag == "TiroBasico"){
			Destroy (this.gameObject);
		}

	}
}
