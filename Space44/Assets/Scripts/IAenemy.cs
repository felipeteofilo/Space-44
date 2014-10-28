using UnityEngine;
using System.Collections;

public class IAenemy : MonoBehaviour
{



		public float Life;//Vida do inimigo
		public float DmgPerColison;//Dano ao colidir 
		public float Speed;//velocidade de movimento
		public GameObject Way;//Caminho ate Player
		public Vector3 destiny;//Vector 3 do Caminho
		public GameObject Target;//Player marcado como alvo de tiros
		public GameObject Aim;//Mira do inimigo(usado no W.InTarget)
		Vector3 Bullet;//Vector 3 do Target
		public ParticleSystem Tiro;//Particulas de tiros
		private float cooldown = 2.0f;//cooldown de tiro pra outro
		private float nextFire; //tempo para o proximo tiro
		public GameObject explosion; 
		public enum E
		{
				Foward,
				JustGo,
				Follower}
		;//enum de tipos de inimigos(Vai pra frente,vai no player ao ve-lo,segue o player ate bem perto)
		public E enemy = E.Foward;//Definindo padrao com Foward
		public enum W
		{
				Foward,
				InTarget}
		;//Defini o comportamento do tiro(Pra frente em Z,e na direçao em que player estiver)
		public W weapon = W.Foward;//Definindo padrao com Foward

		// Use this for initialization
		void Start ()
		{
				if (GameObject.FindGameObjectWithTag ("Player")) {
						Target = GameObject.FindGameObjectWithTag ("Player");
						Way = GameObject.FindGameObjectWithTag ("Player");
				}

				if (enemy == E.JustGo) {
						Speed = 0.1f;
						if (Way != null) {
								destiny = Way.transform.position;
								transform.LookAt (destiny);
						}
				}
				if (enemy == E.Foward) {
						Speed = 0.12f;
				}
				if (enemy == E.Follower) {
						Speed = 0.1f;

				}
	
		}
	
		// Update is called once per frame
		void Update ()
		{
				Physics.IgnoreLayerCollision (8,12);
				if (enemy == E.JustGo) {
						transform.Translate (new Vector3 (0, 0, Speed));

				}
				if (enemy == E.Foward) {		
						transform.Translate (new Vector3 (0, 0, Speed));

				}
				if (enemy == E.Follower) {
						if (Way != null) {
								destiny = Way.transform.position;
						}
						if (transform.position.z > destiny.z + 2.5f) {
								transform.LookAt (destiny);
								transform.Translate (new Vector3 (0, 0, Speed));
				
						} else {
								transform.Translate (new Vector3 (0, 0, Speed));
				
						}
			
				}
				if (weapon == W.InTarget) {
						if (Target != null) {
								Bullet = Target.transform.position;
			
								Aim.transform.LookAt (Bullet);
						}
				}
				//Tiro na direçao em que nave olhar
				//Nao se faz nada
				if (Time.time > nextFire && Target != null && transform.position.z > Target.transform.position.z) {	
						Tiro.Emit (1);
						nextFire = Time.time + cooldown;
				}
		}
	void OnCollisionEnter (Collision collision){
		if(collision.transform.tag == "Player"){
			Instantiate(explosion,transform.position,transform.rotation);
			Destroy(gameObject);
		}
		if(collision.transform.tag == "Enemy"){
			if(enemy == E.JustGo ){
				destiny = new Vector3(-destiny.x,destiny.y,destiny.z);
				transform.LookAt(destiny);
			}

		}
		if(collision.transform.tag == "Boss"){
			Instantiate(explosion,transform.position,transform.rotation);
			Destroy(gameObject);
		}
		if(collision.transform.tag == "Asteroid"){
			SendMessage("AplyDamage",1f);
			Destroy(collision.gameObject,0.5f);

		}
		 

		
	}}

