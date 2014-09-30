using UnityEngine;
using System.Collections;

public class BonusItem : MonoBehaviour
{

		public int points;
		public float life;
		public float activeTime;
		public float deadTime;
		public ParticleSystem collision;


		// Use this for initialization
		void Start ()
		{

				activeTime = Time.time;
	
		}
	
		// Update is called once per frame
		void Update ()
		{
				if (Time.time - activeTime >= deadTime) {
						Destroy (gameObject);
				}
		}

		void AddLife (Collider other)
		{
				if (other.GetComponent<Status> ().life + life < other.GetComponent<Status> ().MaxLife) {
						other.GetComponent<Status> ().life = other.GetComponent<Status> ().life + life;
				} else {
						other.GetComponent<Status> ().life = other.GetComponent<Status> ().MaxLife;
				}
		}

		void AddPoints (Collider other)
		{
				other.GetComponent<Status> ().ReceivePoints (points);

		}

		void OnTriggerEnter (Collider other)
		{
				
				if (other.tag == "Player") {
						if (life > 0) {
								AddLife (other);
						}
						if (points > 0) {
								AddPoints (other);
						}
						collision.Play ();
						collision.transform.parent = null;
						Destroy (collision, collision.duration);
						Destroy (gameObject);
				}
		}
}
