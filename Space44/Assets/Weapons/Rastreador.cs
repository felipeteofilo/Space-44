using UnityEngine;
using System.Collections;

public class Rastreador : MonoBehaviour
{
		public GameObject[] enemies;
		private GameObject target;
		public GameObject pai;
		public GameObject explosion;
		public float speed;
	public float dmg ;
		private float timeToFollow;
	private float TimeStart;
	public float TimeToDie;
	public float[] limitsX = new float[2];
	public float[] limitsZ = new float[2];


		// Use this for initialization
		void Start ()
		{
				FindTarget ();
		TimeStart = Time.time;
		dmg = GameObject.FindWithTag("Player").GetComponent<Status>().damageSpecific;
		Debug.Log(dmg);
		}

		void FindTarget ()
		{
				enemies = GameObject.FindGameObjectsWithTag ("Enemy");
				if (enemies.Length > 0) {

						target = enemies [0];
			
						if (GameObject.FindGameObjectWithTag ("Boss") != null) {
								enemies [enemies.Length] = GameObject.FindGameObjectWithTag ("Boss");
						}
						if (enemies.Length > 1) {
								for (int i=1; i<enemies.Length; i++) {
										if (Vector3.Distance (gameObject.transform.position, target.transform.position) >
												Vector3.Distance (gameObject.transform.position, enemies [i].transform.position)) {
												target = enemies [i];
						
										}
								}
						}
				}
				if (GameObject.FindGameObjectWithTag ("Boss") != null) {
			target =  GameObject.FindGameObjectWithTag ("Boss");
						
				}
		}

		// Update is called once per frame
		void Update ()
		{
				if (target != null && target.activeSelf) {
						//pai.transform.LookAt(target.transform);
						//transform.rotation.eulerAngles = Quaternion(new Vector3(0,transform.rotation.y,0));
						Vector3 dir = target.transform.position - pai.transform.position;
						pai.transform.Translate (new Vector3 (0, 0, speed));
						//pai.transform.forward=dir;
						pai.transform.forward = Vector3.Lerp (pai.transform.forward, dir.normalized, Time.deltaTime * 2);

				} else {
						pai.transform.Translate (new Vector3 (0, 0, speed));
						FindTarget ();
				}
		if(TimeToDie < Time.time - TimeStart){
			Destroy(pai);
			//	Instantiate(explosion,pai.transform.position,pai.transform.rotation);
		}
		/*if((pai.transform.position.x > limitsX[0] || pai.transform.position.x < limitsX[1])
		   || (pai.transform.position.z > limitsZ[0] || pai.transform.position.z < limitsZ[1])){
			Destroy(pai);

		}*/

		}

		void OnTriggerEnter (Collider c)
		{

				if (c.tag == "Enemy" || c.tag == "Boss") {
						c.SendMessageUpwards ("AplyDamage", dmg);
						//	Instantiate(explosion,pai.transform.position,pai.transform.rotation);
						Destroy (pai);


				}

		}
}
