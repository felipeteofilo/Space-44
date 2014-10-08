using UnityEngine;
using System.Collections;

public class Status : MonoBehaviour
{

		public float MaxLife;
		public float life;
		public float speed;
		public float stability;
		public float damage;
		public float fireRate;
		public float damageSpecific;
		public float rechargeShield;
		public float rechargeSpecific;
		public float timeShield;
		public float timeSpecific;
		public float actualSpecificTime;
		public float actualShieldTime;
		public float shieldResistence;
		public Transform explosion;
		public int levelPoints;
		public int totalPoints;


		// Use this for initialization
		void Start ()
		{
	
		}
	
		// Update is called once per frame
		void Update ()
		{

				if (life <= 0) {
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
