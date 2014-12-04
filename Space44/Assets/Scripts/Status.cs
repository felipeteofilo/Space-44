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
		public int bullets = 1;
		public float fireRate;
		public float bonusRate = 0;//
		public float damageSpecific;
		public float rechargeShield;
		public float rechargeSpecific;
		public float timeShield;
		public float bonusTimeShield = 0;
		public float timeSpecific;
		public float bonusSpecific = 0;//
		public float actualSpecificTime;
		public float actualShieldTime;
		public float shieldResistence;
		public Transform explosion;
		public int levelPoints;
		public int totalPoints;
		public int nave;
		public float MinLife;
		public float MinSpeed;
		public float MinStability;
		public float MinFireRate;
		public float MinBonusShield;
		public float MinBonusSpecific;
		private SaveScript s;
		// Use this for initialization
		void Start ()
		{
				s = GameObject.FindGameObjectWithTag ("Global").GetComponent<GlobalStatus> ().status;

				MinLife = MaxLife;
				MinSpeed = speed;
				MinStability = stability;

				MinFireRate = fireRate;
				MinBonusShield = timeShield;
				MinBonusSpecific = timeSpecific;



				CheckStatus ();


		}

		public void CheckStatus ()
		{
				if (s != null) {
			
						BonusLife = s.BonusLife;
						bonusRate = s.BonusRate;
						BonusSpeed = s.BonusSpeed;
						BonusStabilty = s.BonusStability;
						bonusSpecific = s.BonusSpecific;
						bonusTimeShield = s.BonusShield;
						bullets = s.bullets;
						lvlDamage = s.lvlDamage;
			
				}
				MaxLife = MinLife + BonusLife;
				life = MaxLife;
				stability = MinStability + BonusStabilty;
				speed = MinSpeed + BonusSpeed;
				fireRate = MinFireRate - bonusRate;
				timeShield = MinBonusShield + bonusTimeShield;
				timeSpecific = (MinBonusSpecific*bonusSpecific)+MinBonusSpecific;


		}
	
		// Update is called once per frame
		void Update ()
		{

				if (life <= 0) {
					//	s.TotalPoints += levelPoints/2;
						destroyParticlesByTime ();
						Destroy (this.gameObject);
						Instantiate (explosion, this.gameObject.transform.position, Quaternion.identity);
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
