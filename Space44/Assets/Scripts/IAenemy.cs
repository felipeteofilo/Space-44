using UnityEngine;
using System.Collections;

public class IAenemy : MonoBehaviour {

	public float Speed;
	public GameObject Way;
	Vector3 destiny;
	public GameObject Target;
	public GameObject Aim;
	Vector3 Bullet;
	public ParticleSystem Tiro;
	float cooldown = 0;
	 public enum E{Foward,JustGo,Follower};
	public E enemy = E.Foward;
	public enum W{Foward,InTarget,Follower};
	public W weapon = W.InTarget;

	// Use this for initialization
	void Start () {


		if(enemy == E.JustGo){
			Speed = 0.1f;
			destiny = Way.transform.position;
			transform.LookAt (destiny);
		}
		if(enemy == E.Foward){
			Speed = 0.1f;
		}
		if(enemy == E.Follower){
			Speed = 0.1f;

		}
	
	}
	
	// Update is called once per frame
	void Update () {

		if(enemy == E.JustGo){
			transform.Translate (new Vector3 (0, 0, Speed));
		}
		if(enemy == E.Foward){		
			transform.Translate (new Vector3 (0, 0, Speed));
		}
		if(enemy == E.Follower){
			destiny = Way.transform.position;
			if (transform.position.z > destiny.z + 2.5f) {
				transform.LookAt (destiny);
				transform.Translate (new Vector3 (0, 0, Speed));
				
			} else {
				transform.Translate (new Vector3 (0, 0, Speed));
				
			}
			
		}
		if(weapon == W.InTarget){
		Bullet = Target.transform.position;
		Aim.transform.LookAt(Bullet);
		}
		if(weapon == W.Follower){
		}


		cooldown -= Time.deltaTime;


		if (cooldown <0) {
						Tiro.Emit (1);
			cooldown =0.5f;
				}
	
	}
}
