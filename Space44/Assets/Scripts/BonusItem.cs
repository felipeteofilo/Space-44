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
	{	if (other.GetComponent<Status> () != null) {
						if (other.GetComponent<Status> ().life + life < other.GetComponent<Status> ().MaxLife) {
								other.GetComponent<Status> ().life = other.GetComponent<Status> ().life + life;
						} else {
								other.GetComponent<Status> ().life = other.GetComponent<Status> ().MaxLife;
						}
				} else {
			if (other.GetComponentInParent<Status> ().life + life < other.GetComponentInParent<Status> ().MaxLife) {
				other.GetComponentInParent<Status> ().life = other.GetComponentInParent<Status> ().life + life;
			} else {
				other.GetComponentInParent<Status> ().life = other.GetComponentInParent<Status> ().MaxLife;
			}
				
		
		}
		}

		void AddPoints (Collider other)
	{		if (other.GetComponent<Status>() == null) {
						other.GetComponentInParent<Status> ().ReceivePoints (points);
				} else {
			other.GetComponent<Status>().ReceivePoints (points);
				
		}

		}

		void OnTriggerEnter (Collider other)
		{
				
		if (other.tag == "Player" || other.tag == "Shield") {
						if (life > 0) {
								AddLife (other);
						}
						if (points > 0) {
								AddPoints (other);
						}
						collision.Play ();
			Destroy (gameObject,collision.duration);
						
				}
		if(other.tag == "Limit"){
			Debug.Log("teste1");
			Destroy(gameObject);
		}
		}
}
