using UnityEngine;
using System.Collections;

public class TurretCollision : MonoBehaviour {

	public Transform explosion;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {


	
	}

	void OnParticleCollision ( GameObject other) {

		if (other.tag == "TiroBasico") {


			Object exp = Instantiate(explosion, gameObject.transform.position, Quaternion.identity);
			Destroy (gameObject);
			 
		}

	}

}
