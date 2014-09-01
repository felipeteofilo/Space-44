using UnityEngine;
using System.Collections;

public class AsteroidIA : MonoBehaviour {
	public float speed;
	// Use this for initialization
	void Start () {

		rigidbody.velocity = transform.forward * speed;
	
	}
	

}
