using UnityEngine;
using System.Collections;

public class Status : MonoBehaviour
{
		
		public float MaxLife;
		public float life;
		public float BonusLife = 0;//
		public float speed;
		public float BonusSpeed = 0;//
		public float stability;
		public float BonusStabilty = 0;//
		public float damage;
		public float lvlDamage = 1;//
		public int bullets =1;
		public float fireRate;
		public float bonusRate = 0;//
		public float damageSpecific;
		public float rechargeShield;
		public float rechargeSpecific;
		public float timeShield;
		public float bonusTimeShield =0;
		public float timeSpecific;
		public float bonusSpecific = 0;//
		public float actualSpecificTime;
		public float actualShieldTime;
		public float shieldResistence;
		public Transform explosion;
		public int levelPoints;
		public int totalPoints;
		public int nave;

	private SaveScript s = new SaveScript();
		// Use this for initialization
		void Start ()
		{
		s = SAVEaNDLOAD.Load (0);
		if (s != null) {
			Debug.Log("caiu aqui!");
						BonusLife = s.BonusLife;
						bonusRate = s.BonusRate;
						BonusSpeed = s.BonusSpeed;
						BonusStabilty = s.BonusStability;
						bonusSpecific = s.BonusSpecific;
						bonusTimeShield = s.BonusShield;
						bullets = s.bullets;
				}

		MaxLife = MaxLife + BonusLife;
		life = MaxLife;
		stability += BonusStabilty;
		speed += BonusSpeed;
		fireRate -= bonusRate;
		timeShield += bonusTimeShield;
		timeSpecific += bonusSpecific;

	}
	
		// Update is called once per frame
		void Update ()
		{

				if (life <= 0) {
						destroyParticlesByTime ();
						Destroy (this.gameObject);
						Instantiate (explosion, this.gameObject.transform.position, Quaternion.identity);
				}

		if(Input.GetKeyDown(KeyCode.Y)){

			 s.BonusLife = BonusLife;
			 s.BonusRate = bonusRate;
			 s.BonusSpeed = BonusSpeed;
			 s.BonusStability = BonusStabilty;
			 s.BonusSpecific = bonusSpecific;
			 s.BonusShield = bonusTimeShield;
			 s.bullets = bullets ;
			 s.TotalPoints = levelPoints ;
			 s.nave = nave;



			SAVEaNDLOAD.Save(s,nave);
		}
	
		}

		public void ReceivePoints (int pointsToReceive)
		{

				levelPoints += pointsToReceive;

		}

		void destroyParticlesByTime ()
		{
				ParticleSystem particle;
				particle = this.gameObject.GetComponentInChildren<ParticleSystem> ();

				particle.Stop ();

				particle.transform.parent = null;

				GameObject.Destroy (particle.gameObject, particle.duration);
		}
}
