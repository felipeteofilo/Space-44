using UnityEngine;
using System.Collections;

public class Bomb : MonoBehaviour {

	public float Timer;
	public float speed;
	public GameObject  player;
	public float X;
	public GameObject explosion;
	public Light TimerLight;
	public float nextLight;
	public float lightRate;


	// Use this for initialization
	void Start () {
		if(GameObject.FindGameObjectWithTag("Player")!=null){
		player = GameObject.FindGameObjectWithTag("Player");
			transform.LookAt(player.transform.position);
		}

		X = Time.time;

	}
	
	// Update is called once per frame
	void Update () {
		if((Time.time - X) < Timer/4){
			lightRate = 0.5f;

		}else{
			if((Time.time - X) < Timer/2){
				lightRate = 0.25f;
			
		}else{	
		if((Time.time - X) < Timer){
			lightRate = 0.1f;

				}
			}
		}

		if(Time.time > nextLight){
			TimerLight.enabled =true;
			nextLight = Time.time + lightRate;
		}else{
			TimerLight.enabled =false;
		}



		if(GameObject.FindGameObjectWithTag("Player")!=null){
		if(Time.time - X > Timer  ){
			//Explode
			Destroy(gameObject);
			Instantiate (explosion,transform.position,transform.rotation);


		}
		else{
			transform.Translate(new Vector3(0,0,speed));
		
			}
		}else{
			transform.Translate(new Vector3(0,0,-speed));
			if(Time.time - X > Timer  ){
				Destroy(gameObject);
				Instantiate (explosion,transform.position,transform.rotation);

			}
		}

	}
	void OnCollisionEnter(Collision collison){
		//Explode



		if(collison.transform.CompareTag("Player")){

			//Explode
			Destroy(collison.gameObject);
			Destroy(gameObject);
			Instantiate (explosion,transform.position,transform.rotation);
		


		}


	}
}
