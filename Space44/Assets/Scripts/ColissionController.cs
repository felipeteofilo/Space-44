using UnityEngine;
using System.Collections;

public class ColissionController : MonoBehaviour
{
		public Transform explosion;
		private DamageController damageController;
		private float timeToFlash = 0.3f;
		private float timeNextFlash;
		// Use this for initialization
		void Start ()
		{
				damageController = GameObject.FindObjectOfType<DamageController> ();

		}
	
		void OnParticleCollision (GameObject other)
		{
				if (Time.time > timeNextFlash && this.gameObject.collider.enabled == true) {
						timeNextFlash = Time.time + timeToFlash;
						StartCoroutine (FlashPlayer (0.03f));
				}

				if (this.gameObject.collider.enabled) {
						damageController.AplyDamage (other.tag, this.gameObject);
				}


		}

		IEnumerator FlashPlayer (float intervalTime)
		{

				float elapsedTime = 0f;
				float time = Time.deltaTime;
				Color color = new Color(0,0,0); 

				Transform childRenderer = null;
				foreach (Transform child in transform) {
						if (child.name == "body") {
								childRenderer = child;
								color = childRenderer.renderer.material.color;
								;
						}
				}
				while (elapsedTime < time) {
						if (childRenderer != null) {
								childRenderer.renderer.material.color = new Color (255,255,255);
						}
						elapsedTime += Time.deltaTime;
						yield return new WaitForSeconds (intervalTime);
				}
				if (childRenderer != null) {
						childRenderer.renderer.material.color = color;
				}
		}

		void OnCollisionEnter (Collision collision){


		if (collision.gameObject.layer != 11) {
						Destroy (this.gameObject);
						Instantiate (explosion, gameObject.transform.position, Quaternion.identity);
						if (collision.gameObject.tag != "Boss") {
								Destroy (collision.gameObject);
								Instantiate (explosion, collision.gameObject.transform.position, Quaternion.identity);
						}
				}

		}
}
