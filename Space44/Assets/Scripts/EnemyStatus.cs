using UnityEngine;
using System.Collections;

public class EnemyStatus : MonoBehaviour
{


		public float life;
		public float speed;
		public float damage;
		public float fireRate;
		public int pointsByDead;
		public int pointsByDrop;
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
				lifeDropRate = 20;
				pointsDropRate = 80;
				
		}
	
		// Update is called once per frame
		void Update ()
		{

				if (life <= 0) {
						destroyParticlesByTime ();
						Destroy (gameObject);
						Instantiate (explosion, this.gameObject.transform.position, Quaternion.identity);
						GameObject.FindGameObjectWithTag ("Player").GetComponent<Status> ().ReceivePoints (pointsByDead);
						Drop ();
				}
	
		}

		void Drop ()
		{
				float percent = Random.Range (1, 100);
				
				if (percent <= pointsDropRate) {
						Instantiate (pointsObject, this.gameObject.transform.position, Quaternion.identity);
				} else if (percent <= lifeDropRate + pointsDropRate) {
						Instantiate (lifeObject, this.gameObject.transform.position, Quaternion.identity);
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

	void AplyDamage(float dmg){
		life -=dmg;
	}
}
