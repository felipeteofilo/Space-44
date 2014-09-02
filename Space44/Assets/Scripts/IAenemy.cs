using UnityEngine;
using System.Collections;

public class IAenemy : MonoBehaviour {



	public float Life;//Vida do inimigo
	public float DmgPerColison;//Dano ao colidir 
	public float Speed;//velocidade de movimento
	public GameObject Way;//Caminho ate Player
	Vector3 destiny;//Vector 3 do Caminho
	public GameObject Target;//Player marcado como alvo de tiros
	public GameObject Aim;//Mira do inimigo(usado no W.InTarget)
	Vector3 Bullet;//Vector 3 do Target
	public ParticleSystem Tiro;//Particulas de tiros
	private float cooldown = 0.5f;//cooldown de tiro pra outro
	private float nextFire; //tempo para o proximo tiro
	public enum E{Foward,JustGo,Follower};//enum de tipos de inimigos(Vai pra frente,vai no player ao ve-lo,segue o player ate bem perto)
	public E enemy = E.Foward;//Definindo padrao com Foward
	public enum W{Foward,InTarget};//Defini o comportamento do tiro(Pra frente em Z,e na direçao em que player estiver)
	public W weapon = W.Foward;//Definindo padrao com Foward

	// Use this for initialization
	void Start () {

		Target = GameObject.FindGameObjectWithTag("Player");
		Way =  GameObject.FindGameObjectWithTag("Player");

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
		//Tiro na direçao em que nave olhar
		//Nao se faz nada
		if(Time.time >  nextFire){	
			Tiro.Emit(1);
			nextFire = Time.time + cooldown;
		}
	
	}
	void GetDamage(float dmg){
		Life -=dmg;
		if(Life<=0){
			//play animation of explosion
			Destroy(gameObject);
		}

	}
//	void OnTriggerEnter(Collider others){
//
//		if(others.tag == "Player"){
//		//Send colision to player
//			others.transform.Translate(new Vector3 (0, 0, (Speed*(-15))));
//			transform.Translate (new Vector3 (0, 0, (Speed*(-15))));
//
//			GetDamage(DmgPerColison/2);
//
//		//empurra player pra tras
//		}
//		if(others.tag == "Enemy")
//		{	
//			GetDamage(DmgPerColison/4);
//
//			transform.Translate (new Vector3 (0, 0, (Speed*-2)));
//			destiny.x = -destiny.x;
//			transform.LookAt(destiny);
//			//so funciona com goto
//
//
//			//empurra inimigo para lado oposto que veio
//
//		}
//		if(others.tag =="Meteor"){
//			GetDamage(Life);
//		}
//	}
}
