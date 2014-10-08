using UnityEngine;
using System.Collections;

public class BombPlayer : MonoBehaviour {



	public float Timer;
	public float speed;
	public float dmg;
	private float X;
	public GameObject explosion;
	public Light TimerLight;
	private float nextLight;
	private float lightRate;

	
	
	// Use this for initialization
	void Start () {
		dmg = GameObject.FindWithTag("Player").GetComponent<Status> ().damageSpecific;
		X = Time.time;
		//explosion.SendMessageUpwards("setDmg",dmg);
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
		
		
		
	
			if(Time.time - X > Timer  ){
				//Explode
				Instantiate (explosion,transform.position,transform.rotation);
				//explosion.SendMessageUpwards("setDmg",dmg);
			GameObject.FindWithTag("Boom").SendMessage("setDmg",dmg);	
			Destroy(gameObject);
				
				
			}
			else{
				transform.Translate(new Vector3(0,0,speed));
				
			}
		

		
	}
	void OnCollisionEnter(Collision collison){
		//Explode
		
		
		
		if(collison.transform.CompareTag("Enemy")||collison.transform.CompareTag("Boss")){
			
			//Explode
			Instantiate (explosion,transform.position,transform.rotation);
			//explosion.SendMessageUpwards("setDmg",dmg);
			GameObject.FindWithTag("Boom").SendMessage("setDmg",dmg);
			Destroy(gameObject);

			
			
			
		}
		
		
	}
}
