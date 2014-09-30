using UnityEngine;
using System.Collections;

public class ExperienceMoviment : MonoBehaviour {
	public float rotationYMax;
	public float rotationYMin;
	public float speed;


	// Use this for initialization
	void Start () {

		float yRotation = Random.Range (rotationYMin, rotationYMax);
		transform.rotation = Quaternion.Euler(transform.rotation.x, yRotation, transform.rotation.z);
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (new Vector3(0,0,speed));
	}
}
