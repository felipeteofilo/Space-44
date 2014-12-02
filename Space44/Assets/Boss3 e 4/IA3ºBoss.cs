using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class IA3ºBoss : MonoBehaviour
{
		public enum Weapon
		{
				Wait,
				FrontBullets,
				Lasers,
				BackBullets,
				Death
		}
		public ParticleSystem[]BulletsFront;
		public  float fireRate1;
		private float nextFire1;
		private bool cont = true;
		public ParticleSystem[]BulletsBack;
		public  float fireRate2;
		private float nextFire2;
		private bool OnFire = false;
		private float Y = 0;
		private float rotation = 1.5f;
		//{
		public ParticleSystem[]Lasers;
		private int[]order = {0,1,2,3,4,5};
		private bool reseter = false;
		public  float LaserAddRate;
		private float nextLaserAdd;
		public  float LaserRate;
		private float nextLaser;
		private int V = 0;
		private bool wait = true;
		private bool addOrRemove = true;
		//}
		public float StartPoint;
		public float speed;

		public GameObject[]Spawners;
		
		public GameObject Bomb;
		public  float bombRate;
		private float nextBomb;

		public GameObject BombBulletHell;
		private bool OnSecondBomb = false;
		public  float bombRate2;
		private float nextBomb2;

		public float MaxLife;
		public float CurrentLife;
		private float Recovery;
		private float nextCure;
		public float CureRate;

		public Weapon W;
		private bool Change = false;
		public float ChanceOfFrontWeapons;
		private float rotateChange = 0;
		public float ChangeRate;
		private float NextChange;
		private float randomize = 0;

	public GameObject[] spots;
	private bool ThreadOn =false;
	public GameObject explosion;
	public GameObject bigExplosion;
		// Use this for initialization
		void Start ()
		{
				
				Recovery = MaxLife / 200;
				NextChange = Time.time + ChangeRate;
		}
	
		// Update is called once per frame
		void Update ()
		{
				LifeControler ();
				if (W == Weapon.Wait) {
						Coming ();
				}
				if (W == Weapon.Lasers) {
						Laser ();
				}
				if (W == Weapon.FrontBullets) {
						FrontBullets ();
				}
				if (W == Weapon.BackBullets) {
						BackBullets ();
				}
				if(Time.time > NextChange){
					Changing();
			}
				/*if(W == Weapon.Death){
			Death();
		}*/


		}

		void LifeControler ()
		{

				if (Time.time > nextCure) {
						nextCure = Time.time + CureRate;
						if (CurrentLife + Recovery < MaxLife) {
								CurrentLife += Recovery;
						} else {
								CurrentLife = MaxLife;
						}
				}
				if (CurrentLife <= MaxLife) {
						OnSecondBomb = false;
						OnFire = false;
						CureRate = 3;
						ChanceOfFrontWeapons = 80;
				}
				if (CurrentLife <= MaxLife * 0.75f) {
						OnFire = true;	
						OnSecondBomb = false;
						CureRate = 2.75f;
						ChanceOfFrontWeapons = 70;
				}
				if (CurrentLife <= MaxLife * 0.5f) {
						CureRate = 2.5f;
						OnFire = true;	
						OnSecondBomb = true;
						ChanceOfFrontWeapons = 60;
				
				}
				if (CurrentLife <= MaxLife * 0.25f) {
						CureRate = 2;
						ChanceOfFrontWeapons = 50;
				}
		if(CurrentLife <= 0){
			if (!ThreadOn) {
			StartCoroutine (ThreadDestruction ());
			ThreadOn = true;
			}
		}



		}

	public void AplyDamage (float dmg)
		{
				if (W != Weapon.Wait) {
						if (CurrentLife - dmg > 0) {
								CurrentLife -= dmg;
						} else {
								CurrentLife = 0;
						}
				}
		}

		void Coming ()
		{
				if (transform.position.z <= StartPoint) {
						W = Weapon.FrontBullets;
						Change = false;
		}else{
			transform.Translate (new Vector3 (0, 0, speed));
		}

		}

		void FrontBullets ()
		{


				if (cont) {
						if (Time.time > nextFire1) {
								for (int i =0; i<6; i++) {
										BulletsFront [i].Emit (1);
								}
								cont = false;
								nextFire1 = Time.time + fireRate1;
						}

				} else {
						if (Time.time > nextFire1) {
								for (int i =6; i<12; i++) {
										BulletsFront [i].Emit (1);
								}
								cont = true;
								nextFire1 = Time.time + fireRate1;
						}
						Bombs ();


				}


		}

		void Bombs ()
		{
				if (Time.time > nextBomb) {

			Instantiate (Bomb, Spawners [0].transform.position, Spawners [0].transform.rotation);
						nextBomb = Time.time + bombRate;
				}




		}

		void BackBullets ()
		{
				if (Time.time > nextFire2) {
						BulletsBack [0].Emit (1);
						nextFire2 = Time.time + fireRate2;
						if (OnFire) {
								BulletsBack [1].Emit (1);
						}
				}
				BulletsBack [0].transform.Rotate (new Vector3 (0, rotation, 0));
				BulletsBack [1].transform.Rotate (new Vector3 (0, -rotation, 0));
				Y += 1.5f;
				if (Y >= 80) {
						Y *= -1;
						rotation *= -1;
				}
				BombBullet ();
		}

		void BombBullet ()
		{
				if (!OnSecondBomb) {
						int ale = (int)Random.Range (1, 3);
						if (Time.time > nextBomb2 && ale != 3) {
				
								Instantiate (BombBulletHell, Spawners [ale].transform.position, Spawners [ale].transform.rotation);
								nextBomb2 = Time.time + bombRate2;
						}
				} else {
						if (Time.time > nextBomb2) {
								Instantiate (BombBulletHell, Spawners [1].transform.position, Spawners [1].transform.rotation);
								Instantiate (BombBulletHell, Spawners [2].transform.position, Spawners [2].transform.rotation);
								nextBomb2 = Time.time + bombRate2;
						}

				}
		}

		void Laser ()
		{
				if (!reseter) {
						OrderUp ();		
				} else {




						if (addOrRemove) {
								if (Time.time > nextLaserAdd && wait) {
										Lasers [order [V]].enableEmission = true;
										V++;
										nextLaserAdd = Time.time + LaserAddRate;
			
								}
						} else {
								if (Time.time > nextLaserAdd && wait) {
										Lasers [order [V]].enableEmission = false;
										V--;
										nextLaserAdd = Time.time + LaserAddRate;
								}
						}
						if (V == -1 && wait) {
								wait = false;
								nextLaser = Time.time + LaserRate;
						}
						if (V == 6 && wait) {
								wait = false;
								nextLaser = Time.time + LaserRate;

						}

				}
				if (Time.time > nextLaser && V == 6) {
						addOrRemove = false;
						wait = true;
						V--;

				}
				if (Time.time > nextLaser && V == -1) {
						addOrRemove = true;
						wait = true;
						reseter = false;
						V++;
				}






		}

		void OrderUp ()
		{
		 
				int n = order.Length;  
				while (n > 1) {  
						n--;  
						int k = Random.Range (0, 5);
						int value = order [k];  
						order [k] = order [n];  
						order [n] = value;

				}  
		
		
		
				reseter = true;
		
		}

		void disableLasers ()
		{
				for (int i = 0; i<Lasers.Length; i++) {
						Lasers [i].enableEmission = false;

				}
		}

		void Changing ()
		{
				
				if (!Change) {
						randomize = Random.Range (1, 100);
						Change = true;
				}
				if (randomize != 0) {
						if (W == Weapon.FrontBullets) {
								if (randomize <= ChanceOfFrontWeapons) {
										W = Weapon.Lasers;
										Change = false;
										NextChange = Time.time + ChangeRate;
										randomize = 0;
										reseter = false;
										addOrRemove = true;
										V = 0;
										wait = true;
										//Debug.Log("randomize="+randomize);
								} else {
										RotateBack();

								}

						} else {
								if (W == Weapon.Lasers) {
										if (randomize <= ChanceOfFrontWeapons) {
												W = Weapon.FrontBullets;
												Change = false;
												NextChange = Time.time + ChangeRate;
												randomize = 0;

										} else {
												RotateBack();

										}
										disableLasers ();
				
								} else {
										if (W == Weapon.BackBullets) {
											rotateFront(randomize);
				
										}
								}
						}
				}
	}
	void RotateBack(){
		transform.Rotate(new Vector3(2,0,0));
		rotateChange +=2;
		if(rotateChange == 180){
			W = Weapon.BackBullets;
				Change = false;
				rotateChange = 0;
				NextChange = Time.time + ChangeRate;
				randomize = 0;
		}

	}
	void rotateFront(float random){
		transform.Rotate(new Vector3(2,0,0));
		rotateChange +=2;
		if(rotateChange == 180){
			if (random <= 50) {
				W = Weapon.FrontBullets;
			} else {
				W = Weapon.Lasers;
				addOrRemove = true;
				reseter = false;
				V = 0;
				wait = true;
			}
			Change = false;
			NextChange = Time.time + ChangeRate;
			rotateChange = 0;
			randomize = 0;
		}
	
	}
	IEnumerator  ThreadDestruction ()
	{


		int z;
		for (z = 0; z<spots.Length -1; z++) {
			Instantiate(explosion,spots[z].transform.position,spots[z].transform.rotation);
			// new WaitForSeconds(1);
			yield return new WaitForSeconds (0.25f);
			
		}
		Instantiate (bigExplosion,spots[z].transform.position,spots[z].transform.rotation);
		yield return new WaitForSeconds (0.75f);
		Destroy (gameObject);
	}

}
