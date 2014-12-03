using UnityEngine;
using System.Collections;

public class IAenemy : MonoBehaviour
{



		public float Life;//Vida do inimigo
		public float DmgPerColison;//Dano ao colidir 
		public float Speed;//velocidade de movimento
		public float speed2;
		public GameObject Way;//Caminho ate Player
		public Vector3 destiny;//Vector 3 do Caminho
		public GameObject Target;//Player marcado como alvo de tiros
		public GameObject Aim;//Mira do inimigo(usado no W.InTarget)
		Vector3 Bullet;//Vector 3 do Target
		public ParticleSystem Tiro;//Particulas de tiros
		public float cooldown = 2.0f;//cooldown de tiro pra outro
		private float nextFire; //tempo para o proximo tiro
		public GameObject explosion;
		private bool BulletRain = false;
		public Vector3 positionForRain;
		private int rotateControl = 0;
		private int speedrotate = 3;
		public ParticleSystem Tiro2;


		public enum E
		{
				Foward,
				JustGo,
				Follower,
				FromHell
		}
		;//enum de tipos de inimigos(Vai pra frente,vai no player ao ve-lo,segue o player ate bem perto)
		public E enemy = E.Foward;//Definindo padrao com Foward
		public enum W
		{
				Foward,
				InTarget,
				Rain
	}
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
						Speed = 0.05f;
						
				}
				if (enemy == E.Foward) {
						Speed = 0.05f;
				}
				if (enemy == E.FromHell) {
						Speed = 0.05f;
						speed2 = Speed;

				}
				if (enemy == E.Follower) {
						Speed = 0.2f;
			
				}
	
		}
	
		// Update is called once per frame
		void Update ()
		{
			



				Physics.IgnoreLayerCollision (8, 12);
				if (enemy == E.JustGo) {
						if (Way != null) {
								destiny = Way.transform.position;

								if (transform.position.z <= 7.5f) {
										transform.Translate (0, 0, Speed * 3);
								} else {
										if (transform.position.x > destiny.x) {
												transform.Translate (Speed, 0, 0);
										} else {
												transform.Translate (-Speed, 0, 0);
										}
								}
						}
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


								Vector3 v = destiny - transform.position;
								transform.Translate (new Vector3 (0, 0, Speed));
								transform.forward = Vector3.Lerp (transform.forward, v.normalized, Time.deltaTime * 5);
				
						} else {
								transform.Translate (new Vector3 (0, 0, Speed));
				
						}
			
				}

				if (enemy == E.FromHell) {
						
						if (!BulletRain) {
								transform.Translate (new Vector3 (0, 0, Speed));

						}

						if (transform.position.z > positionForRain.z - 0.1f && transform.position.z < positionForRain.z + 0.1f) {
								BulletRain = true;

						}
				}



				if (weapon != W.Rain) {
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
				} else {
						if (BulletRain) {
								if (rotateControl == 360) {
										speedrotate *= -1;
								}

								if (rotateControl == 720) {
										BulletRain = false;
					
								} else {

										transform.Rotate (new Vector3 (0, speedrotate, 0));
										rotateControl += 3;

								}


								if (nextFire < Time.time) {

										Tiro.Emit (1);
										Tiro2.Emit (1);
										nextFire = Time.time + cooldown;
								}

						}
				}
		}

		void OnCollisionEnter (Collision collision)
		{
				if (collision.transform.tag == "Player") {
						Instantiate (explosion, transform.position, transform.rotation);
						GetComponent<ColissionController> ().SendMessage ("PiscaAe", 0.03f);
						Destroy (gameObject);

				}

				if (collision.transform.tag == "Boss") {
						Instantiate (explosion, transform.position, transform.rotation);
						Destroy (gameObject);
				}
				
		 

		
		}
}

