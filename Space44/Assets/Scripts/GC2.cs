using UnityEngine;
using System.Collections;

public class GC2 : MonoBehaviour {

		public GUIText restart;
		public GameObject Formacao1;
		public GameObject Formacao2;
		public GameObject Formacao3;
		public GameObject Formacao4;
		public GameObject Formacao5;
		public GameObject Cinturao;
		public GameObject boss;
		public GameObject background;
		public Vector3 spawnWaves;
	private bool stopspwan = false;
		[Range(0,100)]
		public int
			percentF1;
		[Range(0,100 )]
		public int
			percentF2;
		[Range(0,100 )]
		public int
			percentF3;
		[Range(0,100 )]
		public int
			percentF4;
		[Range(0,100 )]
		public int
			percentF5;
		
		//	public int percentThirdEnemy;
		//	public int percentFourthEnemy;
		public float spawnRate;
		public float nextSpawn;
		private float earlierX;
		private AudioSource bossSong;
		bool bossIstantiate;
	bool cinturaoInstantiate = false;
		
		public int s;
		public GameObject[] players = new GameObject[4];
		public GameObject planetas ;
		AudioSource[] audios;
		
		// Use this for initialization
		void Start ()
		{
			 audios = GetComponents<AudioSource> ();
				audios[s].Play();
				bossSong = audios [4];
			Instantiate(players[s],new Vector3(0,0,1),Quaternion.Euler(new Vector3(0,0,0)));
			
			
		}
		
		
		
		GameObject ramdomEnemy ()
		{
			float percent = Random.Range (1, 100);
			
			if (percent <= percentF1) {
				return Formacao1;
			} else if (percent <= percentF1 + percentF2) {
				return Formacao2;
			} else if (percent <= percentF1 + percentF2 + percentF3) {
				return Formacao3;
			}else if (percent <= percentF1 + percentF2 + percentF3 +percentF4) {
				return Formacao4;
			}else if (percent <= percentF1 + percentF2 + percentF3 +percentF4 +percentF5) {
				return Formacao5;
			}
			return null;
			
		}
		
		void FixedUpdate ()
		{

			


			if (background.transform.localPosition.z > 2.6f) {
				background.transform.Translate (background.transform.forward * -0.05f);
				//planetas.transform.Translate (background.transform.forward * -0.025f);


			} else if (!bossIstantiate) {
				audios[s].Stop();
				bossSong.Play ();
				ParticleSystem[] stars = GameObject.FindGameObjectWithTag ("Stars").GetComponentsInChildren<ParticleSystem> ();
			for (int i =0; i< stars.Length; i++) {
					stars [i].Pause ();
				}
				Vector3 spawnPosition = new Vector3 (0,0, 15);
				Instantiate (boss, spawnPosition, boss.transform.rotation);
				bossIstantiate = true;
			}
		}
		
		// Update is called once per frame
		void Update ()
		{
			if (!GameObject.FindGameObjectWithTag ("Player")) {
				if (!restart.gameObject.activeSelf) {
					restart.gameObject.SetActive (true);
				}
				if (Input.GetKeyDown (KeyCode.R)) {
					Application.LoadLevel (Application.loadedLevel);
					
				}
				
			}
		if(background.transform.localPosition.z < 215f && background.transform.localPosition.z > 120.4f){
			if(!cinturaoInstantiate){
				Instantiate(Cinturao,new Vector3(0,0,41.50f),Cinturao.transform.rotation);
				cinturaoInstantiate = true;
				stopspwan= true;
			}
		}else{
			cinturaoInstantiate = false;
			stopspwan= false;
		}
		if(background.transform.localPosition.z < 10){
			stopspwan= true;

		}



		if(Time.time > nextSpawn && !stopspwan){
			nextSpawn = Time.time + spawnRate;
			GameObject g = ramdomEnemy();
			Instantiate(g,new Vector3(Random.Range(-6.5f,6.5f),0,23.5f),g.transform.rotation);


		}
		if(bossIstantiate && GameObject.FindGameObjectWithTag("Boss")== null){
			Application.LoadLevel("lvl1");

		}
	}




	}