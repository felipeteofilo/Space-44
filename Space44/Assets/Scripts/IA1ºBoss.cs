using UnityEngine;
using System.Collections;

public class IA1ºBoss : MonoBehaviour {

	public float Life1;
	public float MaxLife1 ;
	public float Life2;
	public float MaxLife2;
	public float Life3;
	public float MaxLife3;
	public GameObject Bomb1;
	public GameObject Bomb2;
	public ParticleSystem Bullet1;
	public ParticleSystem Bullet2;
	public ParticleSystem Bullet3;
	public ParticleSystem Bullet4;

	public ParticleSystem Laser1;
	public ParticleSystem Laser2;

	public float fireRate;
	private float nextFire;
	int Y=0;

	public enum Weapon{Bullet,Laser,Bomb};
	public Weapon W = Weapon.Bullet;
	// Use this for initialization
	void Start () {
		MaxLife1 = Life1;
		MaxLife2 = Life2;
		MaxLife3 = Life3;
	}
	
	// Update is called once per frame
	void Update () {



		if (W == Weapon.Bullet) {
			if(Time.time >  nextFire){	
				Bullet1.Emit(1);
				Bullet2.Emit(1);
				Bullet3.Emit(1);
				Bullet4.Emit(1);
				nextFire = Time.time + fireRate;
			}
			if(MaxLife1/2 >=Life1)
			{	Y+=2;
				transform.Rotate(new Vector3(0,2,0));
				if(Y == 120)
				{
					Y =0;
					W = Weapon.Laser;
				}

			}
		
		}
		if (W == Weapon.Bomb) {

			if(MaxLife3/2 >=Life3)
			{	Y+=2;
				transform.Rotate(new Vector3(0,2,0));
				if(Y == 120)
				{
					Y =0;
					W = Weapon.Bullet;
				}
				
			}	
		
		
		
		}
		if (W == Weapon.Laser) {

			Laser1.Emit(5);
			Laser2.Emit(5);


			if(MaxLife2/2 >=Life2)
			{	Y+=2;
				transform.Rotate(new Vector3(0,2,0));
				if(Y == 120)
				{
					Y =0;
					W = Weapon.Bomb;
				}
				
			}
		
		}




	
	}
}
