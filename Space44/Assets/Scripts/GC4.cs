using UnityEngine;
using System.Collections;

public class GC4 : MonoBehaviour {

		public GameObject restart;
		public GameObject player;
		public float speed;
		public GameObject levelComplete;
		public GameObject Enemy1;
		public GameObject Enemy2;
		public GameObject Enemy3;
		public GameObject Enemy4;
		public GameObject boss;
		public GameObject background;
		public GameObject background2;
		public GameObject background3;
		private int Enemys = 1;

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
		private AudioSource bossSong;
		bool bossIstantiate;
		
		public int s;
		public GameObject[] players = new GameObject[4];
		public GameObject planetas ;
		AudioSource[] audios;
		GlobalStatus global;
		
		// Use this for initialization
		void Start ()
		{
		 global = GameObject.FindGameObjectWithTag("Global").GetComponent<GlobalStatus>();
		if (global != null) {
			s = global.status.nave;
		}
			 audios = GetComponents<AudioSource> ();
				audios[0].Play();
				bossSong = audios [1];
			Instantiate(players[s],new Vector3(0,0,1),Quaternion.Euler(new Vector3(0,0,0)));
			
			
		}
		
		
		
		GameObject ramdomEnemy ()
		{
			float percent = Random.Range (1, 100);
			
			if (percent <= percentF1) {
				spawnRate = 2;
				return Enemy1;
			} else if (percent <= percentF1 + percentF2) {
				spawnRate = 2;
				return Enemy2;
			} else if (percent <= percentF1 + percentF2 + percentF3) {
				spawnRate = 4;
				return Enemy3;
			}else if (percent <= percentF1 + percentF2 + percentF3 +percentF4) {
				spawnRate = 2;
				return Enemy4;
			}
			return null;
			
		}

		
		void FixedUpdate ()
		{
		if(audios[0].time > 48){
			Enemys = 2;

		}
		if(audios[0].time > 120){
			Enemys = 1;
		}
		if(audios[0].time > 165){
			Enemys = 3;
		}
		if(audios[0].time > 195){
			Enemys = 1;
		}
		if (audios [0].time > 220 && audios[0].isPlaying) {
			audios[0].Stop();
		}

		if (background.transform.localPosition.z > -44.15f) {
			background.transform.Translate (background.transform.forward * -0.05f);
			background2.transform.Translate (background2.transform.forward * -0.025f);
			background3.transform.Translate(background3.transform.forward * - 0.02f);		
			//planetas.transform.Translate (background.transform.forward * -0.025f);


			} else if (!bossIstantiate) {
				audios[0].Stop();
				bossSong.Play ();
				ParticleSystem[] stars = GameObject.FindGameObjectWithTag ("Stars").GetComponentsInChildren<ParticleSystem> ();
			for (int i =0; i< stars.Length; i++) {
					stars [i].Pause ();
				}
				Vector3 spawnPosition = new Vector3 (0,0, 44.5f);
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
				
				
			}

		if(background.transform.localPosition.z < -30){
			stopspwan= true;
		}



		if(Time.time > nextSpawn && !stopspwan){
			for(int i = 0 ; i< Enemys;i++){
			GameObject g = ramdomEnemy();
			Instantiate(g,new Vector3(Random.Range(-16f,16f),0,23.5f),g.transform.rotation);
			}
			nextSpawn = Time.time + spawnRate;
		}
		if(bossIstantiate && GameObject.FindGameObjectWithTag("Boss")== null){

			player = GameObject.FindWithTag("Player");
			player.GetComponent<PlayerController>().enabled = false;
			player.transform.Translate(new Vector3(0,0,speed));
			levelComplete.SetActive(true);
			if(player.transform.position.z > 21f){
				
				global.status.TotalPoints += player.GetComponent<Status>().levelPoints;
				Application.LoadLevel("HangarScene");
			}else{
				speed += 0.005f;
			}
			
		}


	
	
	}
	public void RestartLevel(){
		Application.LoadLevel (Application.loadedLevel);
	}
	public void ExitLevel(){
		Application.LoadLevel ("NewGame");
	}






	}