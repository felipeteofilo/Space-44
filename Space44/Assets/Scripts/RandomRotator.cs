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
		if(tag != "Life"){
		transform.localPosition = new Vector3(0,0,0);
		}
	}


}
