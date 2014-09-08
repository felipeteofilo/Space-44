using UnityEngine;
using System.Collections;

public class OutOfView : MonoBehaviour {

	void OnCollisionEnter (Collision collision){

		Destroy (collision.gameObject);
	}
}
