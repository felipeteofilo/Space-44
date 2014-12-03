using UnityEngine;
using System.Collections;

public class JustDie : MonoBehaviour {
	public float speed;
	public GameObject RainOn;
	public GameObject explosion;
	public float zMax;
	
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		RainOn.transform.Rotate(new Vector3(0,1f,0));
		
	}
	
	void Move(){
		
		transform.Translate (new Vector3(0, 0, speed));
		if (transform.position.z < zMax) {
			destroyPaticle();
			Destroy(gameObject);		
		}

	}
	void FixedUpdate(){
		
		Move ();
	}
	void destroyPaticle(){
		ParticleSystem []particle;

		particle = gameObject.GetComponentsInChildren<ParticleSystem> ();
		for (int i = 0; i<particle.Length; i++) {
			particle[i].Stop();
			particle[i].transform.parent = null;
			GameObject.Destroy(particle[i].gameObject,particle[i].duration);
		}




	}
	void OnCollisionEnter (Collision collision){
		if(collision.transform.tag =="Player"){
			Instantiate (explosion,transform.position,transform.rotation);
			collision.transform.SendMessageUpwards("AplyDamage",5f);
			destroyPaticle();
			Destroy (this.gameObject);
		}
	} 


}
