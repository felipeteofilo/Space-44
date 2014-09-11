using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class IA1ºBoss : MonoBehaviour
{

		public float x1;
		public float x2;
		//Internal information
		public float Life1;
		public float MaxLife1 ;
		public float Life2;
		public float MaxLife2;
		public float Life3;
		public float MaxLife3;
		public float Speed;
		public GameObject Bomb;
		//Emptys
		public GameObject Front;
		public GameObject AimBomb1;
		public GameObject AimBomb2;
		public List <GameObject> SpotsOfExplosion = new List<GameObject> ();




		//othres tretas
		
		public GameObject explosion;
		public GameObject bigExplosion;
		//Particles of Bullets
		public ParticleSystem Bullet1;
		public ParticleSystem Bullet2;
		public ParticleSystem Bullet3;
		public ParticleSystem Bullet4;
		//Particles of Laser
		public ParticleSystem Laser1;
		public ParticleSystem Laser2;
		//Fire rate for delay of bullets
		public float fireRate;
		public float BombRate;
		private float nextFire;
		private float nextBomb;
		private float nextCureRate;
		public float CureRate;
		public bool turn = true;
		public bool ThreadOn = false;
		public Vector3 StartBattle = new Vector3 (0, 0, 0);
		int Y = 0;
		public int Z = 0;
		public int  R;

		public enum Weapon
		{
				Bullet,
				Laser,
				Bomb,
				Wait,
				Death}
		;
		public Weapon W = Weapon.Wait;
		// Use this for initialization
		void Start ()
		{
				MaxLife1 = Life1;
				MaxLife2 = Life2;
				MaxLife3 = Life3;




		}
	
		// Update is called once per frame
		void Update ()
		{
				if (W == Weapon.Wait) {
						Front.transform.Translate (new Vector3 (0, 0, Speed));
						if (Front.transform.position.z <= StartBattle.z) {
								W = Weapon.Bullet;
						}
				}


				if (W == Weapon.Bullet) {
						if (Time.time > nextFire) {	
								Bullet1.Emit (1);
								Bullet2.Emit (1);
								Bullet3.Emit (1);
								Bullet4.Emit (1);
								nextFire = Time.time + fireRate;
						}
						if ((MaxLife1 / 2 >= Life1) || Life1 <= 0) {
								Y += 2;
								transform.Rotate (new Vector3 (0, 2, 0));
								
								if (Y == 120) {
										audio.Play ();
										Y = 0;
										W = Weapon.Laser;
										Z = 0;
										MaxLife2 = Life2;
								}

						}
		
				}
				if (W == Weapon.Bomb) {
						if (Time.time > nextBomb) {

								Instantiate (Bomb, AimBomb1.transform.position, Bomb.transform.rotation);
								Instantiate (Bomb, AimBomb2.transform.position, Bomb.transform.rotation);
								nextBomb = Time.time + BombRate;
				
				
						}


						if (MaxLife3 / 2 >= Life3 || Life3 <= 0) {
								Y += 2;
								transform.Rotate (new Vector3 (0, 2, 0));
								if (Y == 120) {
										audio.Play ();
										Y = 0;
										W = Weapon.Bullet;
										Z = 0;
										MaxLife1 = Life1;

								}
				
						}	
		
		
		
				}
				if (W == Weapon.Laser) {

						Laser1.Emit (5);
						Laser2.Emit (5);


						if (MaxLife2 / 2 >= Life2 || Life2 <= 0) {
								Y += 2;
								transform.Rotate (new Vector3 (0, 2, 0));
							
								if (Y == 120) {
										audio.Play ();
										Y = 0;
										W = Weapon.Bomb;
										Z = 0;
										MaxLife3 = Life3;
								}
				
						}
		
				}
				if (W == Weapon.Death) {
						Speed = 0;

				}
				if ((Front.transform.position.x <= x1 || Front.transform.position.x >= x2) && turn) {
						Speed *= -1;
						Z++;
						turn = false;
				}
		//Comparar X de front com limites da tela(caso esteja nos conformes 
		//>>
		else {
						if (W != Weapon.Wait) {
								Front.transform.Translate (new Vector3 (Speed, 0, 0));
								
								turn = true;
						}
				}

				if (Z >= 10) {

						R = (int)Random.Range (1, 4);
						Z = 0;

				}
				if (R == 1) {
		
						if (W == Weapon.Bullet) {
								Y += 2;
								transform.Rotate (new Vector3 (0, 2, 0));
								
								if (Y == 360) {
										audio.Play ();			
										Y = 0;
						
										R = 0;


								}
						}
						if (W == Weapon.Laser) {
								Y += 2;
								transform.Rotate (new Vector3 (0, 2, 0));
								
								if (Y == 240) {
										audio.Play ();			
										Y = 0;

										W = Weapon.Bullet;
										R = 0;
								}

								//shhhh			
						}
						if (W == Weapon.Bomb) {
								Y += 2;
								transform.Rotate (new Vector3 (0, 2, 0));
								
								if (Y == 120) {
										audio.Play ();			
										Y = 0;
						
										W = Weapon.Bullet;
										R = 0;
								}
					
						}


				}
				if (R == 2) {
						if (W == Weapon.Bullet) {
								Y += 2;
								transform.Rotate (new Vector3 (0, 2, 0));
								
								if (Y == 120) {
										audio.Play ();
										Y = 0;

										W = Weapon.Laser;
										R = 0;
					
					
								}
						}
						if (W == Weapon.Laser) {
								Y += 2;
								transform.Rotate (new Vector3 (0, 2, 0));
								
								if (Y == 360) {
										audio.Play ();
										Y = 0;

										R = 0;

								}
				
				
						}
						if (W == Weapon.Bomb) {
								Y += 2;
								transform.Rotate (new Vector3 (0, 2, 0));
								if (Y == 240) {
										audio.Play ();		
										Y = 0;

										W = Weapon.Laser;
										R = 0;
								}
				
						}
			
			
				}
				if (R == 3) {
						if (W == Weapon.Bullet) {
								Y += 2;
								transform.Rotate (new Vector3 (0, 2, 0));
								
								if (Y == 240) {
										audio.Play ();			
										Y = 0;
				
										W = Weapon.Bomb;
										R = 0;
					
					
								}
						}
						if (W == Weapon.Laser) {
								Y += 2;
								transform.Rotate (new Vector3 (0, 2, 0));
								
								if (Y == 120) {
										audio.Play ();			
										Y = 0;

										R = 0;
										W = Weapon.Bomb;
					
								}

				
						}
						if (W == Weapon.Bomb) {
								Y += 2;
								transform.Rotate (new Vector3 (0, 2, 0));
								
								if (Y == 360) {
										audio.Play ();			
										Y = 0;

										R = 0;
								}
				
						}
			
			
				}

				if (Time.time > nextCureRate) {
						if (W != Weapon.Bullet && Life1 > 25) {
								if (Life1 < MaxLife1) {
										Life1++;

								}
						}
						if (W != Weapon.Bomb && Life3 > 25) {
								if (Life3 < MaxLife3) {
										Life3++;
					
								}
				
						}
						if (W != Weapon.Laser) {
								if (Life2 < MaxLife2 && Life2 > 25) {
										Life2++;
					
								}
						}
						nextCureRate = Time.time + CureRate;



				}

				if ((Life1 <= 0) && (Life2 <= 0) && (Life3 <= 0)) {
						if (!ThreadOn) {
								StartCoroutine (ThreadDestruction ());
								ThreadOn = true;
								W = Weapon.Death;
						}

				}



	
		}

		void AplyDamage (float dmg)
		{
				if (W == Weapon.Bullet) {
						Life1 -= dmg;
				}
				if (W == Weapon.Laser) {
						Life2 -= dmg;
				}
				if (W == Weapon.Bomb) {
						Life3 -= dmg;
				}






		}

		IEnumerator  ThreadDestruction ()
		{


			
				for (int i = 0; i<SpotsOfExplosion.Count -1; i++) {
						Instantiate (explosion, SpotsOfExplosion [i].transform.position, SpotsOfExplosion [i].transform.rotation);
						// new WaitForSeconds(1);
						yield return new WaitForSeconds (0.25f);

				}
				Instantiate (bigExplosion, SpotsOfExplosion [9].transform.position, SpotsOfExplosion [9].transform.rotation);
				yield return new WaitForSeconds (0.5f);
				Destroy (gameObject);




		}







}
