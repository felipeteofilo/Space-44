using UnityEngine;
using System.Collections;

public class RotateSpaceShip : MonoBehaviour {

	public float tumble;

	// Use this for initialization
	void Start () {
		//rigidbody.angularVelocity = Random.insideUnitSphere * tumble;

		rigidbody.angularVelocity = new Vector3 (0,-tumble,0);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
