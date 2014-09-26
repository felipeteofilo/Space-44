using UnityEngine;
using System.Collections;

public class BonusItem : MonoBehaviour
{

		public float points;
		public float life;


		// Use this for initialization
		void Start ()
		{
	
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}

		void AumentarVida (Collider other)
		{
				if (other.GetComponent<Status> ().life + life < other.GetComponent<Status> ().MaxLife) {
						other.GetComponent<Status> ().life = other.GetComponent<Status> ().life + life;
				} else {
						other.GetComponent<Status> ().life = other.GetComponent<Status> ().MaxLife;
				}
		}

		void OnTriggerEnter (Collider other)
		{

				if (other.tag == "Player") {
						if (life > 0) {
								AumentarVida (other);
						}
						if (points > 0) {
								Debug.Log ("foi mano" + points);
						}
						Destroy (gameObject);
				}
		}
}
