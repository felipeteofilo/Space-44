using UnityEngine;
using System.Collections;

public class EnemyStatus : MonoBehaviour
{


		public float life;
		public float speed;
		public float damage;
		public float fireRate;
		public float pointsByDead;
		public float pointsByDrop;
		public Transform explosion;
		public GameObject lifeObject;
		public GameObject pointsObject;
		public GameObject energyObject;
		private float lifeDropRate;
		private float pointsDropRate;
		private float energyDropRate;


		// Use this for initialization
		void Start ()
		{
				lifeDropRate = 25;
				pointsDropRate = 45;
				energyDropRate = 10;
		}
	
		// Update is called once per frame
		void Update ()
		{

				if (life <= 0) {
						destroyParticlesByTime ();
						Destroy (this.gameObject);
						Instantiate (explosion, this.gameObject.transform.position, Quaternion.identity);
						Drop ();
				}
	
		}

		void Drop ()
		{
				float percent = Random.Range (1, 100);
				
				if (percent <= energyDropRate) {
						Instantiate (energyObject, this.gameObject.transform.position, Quaternion.identity);
				} else if (percent <= lifeDropRate) {
						Instantiate (lifeObject, this.gameObject.transform.position, Quaternion.identity);
				} else if (percent <= pointsDropRate) {
						pointsObject.GetComponent<BonusItem> ().points = pointsByDrop;
						Instantiate (pointsObject, this.gameObject.transform.position, Quaternion.identity);
				}
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
