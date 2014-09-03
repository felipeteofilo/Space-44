using UnityEngine;
using System.Collections;

public class FuzilFPS : MonoBehaviour
{
		public ParticleSystem muzzle;
		public ParticleSystem estilhacos;
		public GameObject bullethole;
		public GameObject atingido;
		Vector3 lastimpact;
		Vector3 lastimpactN;
		public enum trigger{auto,fullauto};
		public Light muzzleflash;
		public trigger  gatilho = trigger.auto;
		public Animator coice;
		//public AudioSource shoot;
		ArrayList holes;
		// Use this for initialization
		void Start ()
		{
				holes = new ArrayList ();
		}
	
		// Update is called once per frame
		void Update ()
		{


				if (Input.GetButtonDown ("Fire2")) {
						if (gatilho == trigger.auto) {
								gatilho = trigger.fullauto;
						} else {
								gatilho = trigger.auto;
						}
				}
				if (gatilho == trigger.auto)
						auto ();
				if (gatilho == trigger.fullauto)
						fullAuto ();



	
		}

		void auto ()
		{
		//muzzleflash.enabled = false;

				if (Input.GetButtonDown ("Fire1")) {
						muzzle.Emit (1);
						//shoot.Play();
						//muzzleflash.enabled = true;
			coice.SetTrigger("shoot");
			coice.speed = 2;
						Ray ray = new Ray (transform.position, transform.forward);
						RaycastHit hit;
			
						if (Physics.Raycast (ray, out hit, 100)) {
								lastimpact = hit.point;
								lastimpactN = hit.normal;
								estilhacos.transform.position = hit.point;
								atingido = hit.collider.gameObject;
								atingido.SendMessageUpwards("Atingido",SendMessageOptions.DontRequireReceiver);
								//Invoke ("ColiderTimer",null);
								ColiderTimer();
								//estilhacos.Emit(30);
				
								Debug.DrawLine (ray.origin, hit.point);
				
						} else {
				
								Debug.DrawRay (ray.origin, transform.forward * 100);
				
						}
				}

	
		}
	float cooldown = 0;
		void fullAuto ()
		{
		//muzzleflash.enabled = false;		
		cooldown -= Time.deltaTime;
		coice.speed = 2;

				if (Input.GetButton ("Fire1")&&cooldown <0) {
			coice.SetTrigger("shoot");
			coice.speed = 10;
						muzzle.Emit (1);
			cooldown = 0.1f;
			//muzzleflash.enabled = true;

						//shoot.Play();
						
						Ray ray = new Ray (transform.position, transform.forward);
						RaycastHit hit;
			
						if (Physics.Raycast (ray, out hit, 100)) {
								lastimpact = hit.point;
								lastimpactN = hit.normal;
								estilhacos.transform.position = hit.point;
								//Invoke ("ColiderTimer",null);
								ColiderTimer();

								Debug.DrawLine (ray.origin, hit.point);
				
						} else {
				
								Debug.DrawRay (ray.origin, transform.forward * 100);
				
						}
				}





		}

		void ColiderTimer ()
		{
				if (holes.Count > 20) {
						GameObject buraco = (GameObject)holes [Random.Range (0, holes.Count)];
						buraco.transform.position = lastimpact + lastimpactN * 0.001f;
						buraco.transform.rotation = Quaternion.LookRotation (lastimpactN * -1);
			buraco.transform.parent = atingido.transform;
		
		
				} else {
						GameObject buraco = (GameObject)Instantiate (bullethole,
			           lastimpact + lastimpactN * 0.001f, Quaternion.LookRotation (lastimpactN * -1));
			buraco.transform.parent = atingido.transform;			
			holes.Add (buraco);
		
				}
				estilhacos.Emit (30);



		}

}



























