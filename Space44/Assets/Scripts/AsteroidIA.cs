using UnityEngine;
using System.Collections;

public class AsteroidIA : MonoBehaviour {
	public float speed;
	private float life = 30;
	// Use this for initialization

	void Update () {
		if(Time.timeScale!=0){
		Physics.IgnoreLayerCollision (13,12);
		transform.Translate(transform.forward*-speed);
		}
	}
	void AplyDamage(float f){
		life -= f;
	}
	

}
