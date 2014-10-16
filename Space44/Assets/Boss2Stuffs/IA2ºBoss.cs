using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class IA2ºBoss : MonoBehaviour
{
		public List <GameObject> SpotsOfExplosion = new List<GameObject> ();
		public GameObject explosion;
		public GameObject bigExplosion;
		/****Particulas****/
		//Bullets
		public ParticleSystem SlowBullets1;
		public ParticleSystem SlowBullets2;
		public ParticleSystem SlowBullets3;
		public ParticleSystem SlowBullets4;
		public ParticleSystem FastBullets1;
		public ParticleSystem FastBullets2;
		//Charging
		public ParticleSystem Charge1;
		public ParticleSystem Charge2;
		public ParticleSystem Charge3;
		public ParticleSystem Charge4;
		//Giant Laser
		public ParticleSystem BigLaser;
	
		//Gerenciadores de Particulas
		public GameObject GBullets;
		public GameObject GCharge;

		//Gerenciador de Ataques
		public enum Weapon
		{
				Wait,//Chegando para iniciar Luta
				SlowBullets,//Balas lentas ,indo na direçao do player 
				FastBullets,//Balas rapidas para frente
				Charging,//Carregando para laser
				Laser,//Soltando Laser
				Death//Morreu o/
	}
		;
		public Weapon W = Weapon.Wait;
		private Weapon T = Weapon.Wait;//temporary 

		//Variaveis Internas
		//Life...

		public float MaxLife;
		public float CurrentLife;
	static public float guiM;
	static public float guiC;
	//Movement Speed
	static public float guiCLife;
	static public float guiMLife;
		//Movement Speed

		public float Speed;
		public float Speed2;//speed for chase the player in charging laser 
		//delay betwen bullets or bombs
		public float fireRate1;
		public float fireRate2;
		private float nextFire1;
		private float nextFire2;
		public float bombRate;
		private float nextBomb;
		public float CureRate;
		private float nextCure;
		public float bombReloadRate;
		private float nextReloadBomb;
		public float changeRate;
		private float nextChange;
		public float laserRate;
		private float nextLaser;
		public float TimeofLaser;
		private float DurationOfLaser;
		//Position to Start and Limits of X
		public Vector3 startBattle;
		public float X1;//Left Limit
		public float X2;//Right Limit
		//Mover
		public GameObject Front;
		private bool turn = true;//
		private bool BombOn = false;//permits boss use the bombs
		private	bool BombReload = false;//permits the boss reload the bombs
		//random
		private int R = 0;//weapon loads depends of this number
		private int B = 0;//bombs loads in road
		private int Turn = 0;//chose the rotate to the left or right
		
		private int RotateControl = 0;//control the rotate
		public int Range = 8;//range of changing weapons 
		public int RangeOfBombs = 5;//maximum of bombs per load
		//Player
		public GameObject Player;
		//Bomb and position of birth
		public GameObject bombObject;
		public GameObject SBomb;
		private bool ThreadOn = false;
	private bool MovingLaserR = false;
	private bool MovingLaserL = false;


		// Use this for initialization
		void Start ()
		{
				CurrentLife = MaxLife;
				guiMLife = MaxLife;
				if (GameObject.FindGameObjectWithTag ("Player") != null) {
						Player = GameObject.FindGameObjectWithTag ("Player");
					
				}

		}
	
		// Update is called once per frame
		void Update ()
		{
		 guiM =MaxLife;
		 guiC =CurrentLife;
				LifeControler ();
				if (W == Weapon.Wait) {
		
						Begin ();
				}

				if (W == Weapon.SlowBullets) {
						Slow ();
				}

				if (W == Weapon.FastBullets) {
						Fast ();
				}
				if (W == Weapon.Charging) {
						Charge ();
				}
				if (W == Weapon.Laser) {
						Laser ();
				}
				if (Time.time > nextChange && W != Weapon.Wait) {
						Change ();

				}

	
		}

		void FixedUpdate ()
		{
				Move ();
		}

		void Begin ()
		{
				Front.transform.Translate (new Vector3 (0, 0, -Speed));
				if (Front.transform.position.z <= startBattle.z) {
						nextChange = Time.time + changeRate;
						W = Weapon.SlowBullets;
				}

		}

		void Move ()
		{
				if ((Front.transform.position.x <= X1 || Front.transform.position.x >= X2) && turn) {
						Speed *= -1;
						turn = false;
				}
				if (W != Weapon.Wait && W != Weapon.Charging && W != Weapon.Laser && W !=  Weapon.Death) {
						Front.transform.Translate (new Vector3 (Speed, 0, 0));
						turn = true;
				}
		if(Player != null ){
				if (W == Weapon.Charging) {
						turn = false;
			if (Player.transform.position.x > Front.transform.position.x 
			    &&(Front.transform.position.x >= X1+1 || Front.transform.position.x <= X2-1)) {
								Front.transform.Translate (new Vector3 (Speed2, 0, 0));

						}
						if (Player.transform.position.x < Front.transform.position.x
			    &&(Front.transform.position.x >= X1+1 || Front.transform.position.x <= X2-1)) {
								Front.transform.Translate (new Vector3 (-Speed2, 0, 0));
						}
				}
		if (W == Weapon.Laser){
			if(Front.transform.position.x > Player.transform.position.x && !MovingLaserR){
				MovingLaserL = true;
			}
			if(Front.transform.position.x < Player.transform.position.x  && !MovingLaserL){
				MovingLaserR = true;
			}
			if(MovingLaserL && Front.transform.position.x > X1+1){
				Front.transform.Translate (new Vector3 ((-Speed2), 0, 0));
			}
			if(MovingLaserR && Front.transform.position.x < X2-1){
				Front.transform.Translate (new Vector3 ((Speed2), 0, 0));
			}




		}

		}
		}

		void Slow ()
		{
				Bomb ();
				if (Time.time > nextFire1) {
						SlowBullets1.Emit (1);
						SlowBullets2.Emit (1);
						SlowBullets3.Emit (1);
						SlowBullets4.Emit (1);
						nextFire1 = Time.time + fireRate1;
				}
		}

		void Fast ()
		{		
				Bomb ();
				if (Time.time > nextFire2) {
						FastBullets1.Emit (1);
						FastBullets2.Emit (1);
						nextFire2 = Time.time + fireRate2;
				}

		}

		void Charge ()
		{

				GCharge.SetActive (true);
				if (Time.time > nextLaser) {
						DurationOfLaser = Time.time + TimeofLaser;
						W = Weapon.Laser;

				}

		}

		void Laser ()
		{
				GCharge.SetActive (false);
				BigLaser.gameObject.SetActive (true);
				if (Time.time > DurationOfLaser) {
						BigLaser.gameObject.SetActive (false);
						W = T;
						nextChange = Time.time + changeRate;
						R = 0;
			MovingLaserL = false;
			MovingLaserR = false;
			turn = true;
		}

		}

		void Change ()
		{
		if (R == 0 && W != Weapon.Charging && W != Weapon.Laser && W != Weapon.Death) {
						R = (int)Random.Range (1, Range);
						
				}
				if (R == 1 || R == 6 || R == 3) {
						if (W != Weapon.SlowBullets) {
								Rotate ();
						} else {
								Rotate2 ();
						}

				}
				if (R == 2 || R == 5 || R == 4) {
						if (W != Weapon.FastBullets) {
								Rotate ();
						} else {
								Rotate2 ();
						}
				}
				if (R >= 7) {
						T = W;
						W = Weapon.Charging;
						nextLaser = Time.time + laserRate;
						R = 0;


				}



		}

		void Rotate ()
		{
				if (Turn == 0 || Turn == 3) {
						Turn = (int)Random.Range (1, 3);
				
				}
				if (Turn == 1) {
						transform.Rotate (new Vector3 (0, 0, 3));
						RotateControl += 3;
				}
				if (Turn == 2) {
						transform.Rotate (new Vector3 (0, 0, -3));
						RotateControl += 3;
				}
				if (RotateControl == 90) {
						RotateControl = 0;
						Turn = 0;
						R = 0;
						nextChange = Time.time + changeRate;
						if (W == Weapon.FastBullets) {
								W = Weapon.SlowBullets;
						} else {
								if (W == Weapon.SlowBullets) {
										W = Weapon.FastBullets;
								}
						}
				}



		}

		void Rotate2 ()
		{
				if (Turn == 0 || Turn == 3) {
						Turn = (int)Random.Range (1, 3);
				}
				if (Turn == 1) {
						transform.Rotate (new Vector3 (0, 0, 3));
						RotateControl += 3;
				}
				if (Turn == 2) {
						transform.Rotate (new Vector3 (0, 0, -3));
						RotateControl += 3;
				}
				if (RotateControl == 180) {
						RotateControl = 0;
						Turn = 0;
						R = 0;
						nextChange = Time.time + changeRate;


				}
	
		}

		void LifeControler ()
		{	
		guiCLife = CurrentLife;

		if (Time.time > nextCure && W != Weapon.Death) {
			nextCure = Time.time + CureRate;
		

		if (CurrentLife < MaxLife) {

		if (CurrentLife +1.5f < MaxLife) {

			CurrentLife+=1.5f;
			
		}
			else{
				CurrentLife = MaxLife;
			}
			}
		}
		if (CurrentLife <= (MaxLife * 0.75)) {
						Range = 10;
						BombOn = true;
						RangeOfBombs = 5;
						Speed2 = 0.05f;
			changeRate = 10f;


		}else{
			Range = 8;
			BombOn = false;
			Speed2 = 0.05f;
			changeRate = 15;


		}
				if (CurrentLife <= (MaxLife * 0.5)) {
						Range = 12;
						RangeOfBombs = 10;
						Speed2 = 0.05f;
						changeRate = 5f;

				}
				if (CurrentLife <= (MaxLife * 0.25)) {
						Range = 14;
						RangeOfBombs = 15;
						Speed2 = 0.075f;
						changeRate = 2.5f;

				}
				if (CurrentLife <= 0) {
						//
						if (!ThreadOn) {
								StartCoroutine (ThreadDestruction ());
								ThreadOn = true;
								W = Weapon.Death;
						}


				}
		
	}

		void AplyDamage (float dmg)
		{
		if (W != Weapon.Wait) {
						if (CurrentLife - dmg > 0) {
								CurrentLife -= dmg;
						} else {
								CurrentLife = 0;
						}
				}
	}
		
	

		void Bomb ()
		{
				if (BombOn) {
						if (B == 0 && !BombReload) {
								B = (int)(Random.Range (1, RangeOfBombs));
								
						}
						if (Time.time > nextBomb && B > 0) {
								Instantiate (bombObject, SBomb.transform.position, SBomb.transform.rotation);
								nextBomb = Time.time + bombRate;
								B--;
								if (B == 0) {
										BombReload = true;
										nextReloadBomb = Time.time + bombReloadRate;
								}
						}
						if (Time.time > nextReloadBomb) {
								BombReload = false;
						} 
				}
		}
	IEnumerator  ThreadDestruction ()
	{
		BigLaser.gameObject.SetActive (false);
		GCharge.gameObject.SetActive(false);
		
		
		for (int i = 0; i<SpotsOfExplosion.Count -1; i++) {
			Instantiate (explosion, SpotsOfExplosion [i].transform.position, SpotsOfExplosion [i].transform.rotation);
			// new WaitForSeconds(1);
			yield return new WaitForSeconds (0.25f);
			
		}
		Instantiate (bigExplosion, SpotsOfExplosion [7].transform.position, SpotsOfExplosion [7].transform.rotation);
		yield return new WaitForSeconds (0.75f);
		Destroy (Front);

		
		
		
		
	}
}
