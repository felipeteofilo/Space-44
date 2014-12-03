using UnityEngine;
using System.Collections;

public class GC3 : MonoBehaviour {
	
	public GameObject restart;
	public GameObject player;
	public float speed;
	public GameObject levelComplete;
	public GameObject Formacao1;
	public GameObject Formacao2;
	public GameObject Formacao3;
	public GameObject Formacao4;
	public GameObject Formacao5;
	public GameObject boss;
	public GameObject Enemy3;
	public GameObject background;
	public GameObject background2;
	public GameObject background3;
	

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
	bool enemyInstatiate = true;
	
	public int s;
	public GameObject[] players = new GameObject[4];
	public GameObject planetas ;
	AudioSource[] audios;
	GlobalStatus global;
	
	// Use this for initialization
	void Start ()
	{
		//global = GameObject.FindGameObjectWithTag("Global").GetComponent<GlobalStatus>();
		//if (global != null) {
		//	s = global.status.nave;
		//}
		audios = GetComponents<AudioSource> ();
		audios[0].Play();
		bossSong = audios [0];
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
		
		
		
		
		if (background.transform.localPosition.z > -285) {
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
			Vector3 spawnPosition = new Vector3 (0,0, 15);
			Instantiate (boss, spawnPosition, boss.transform.rotation);
			bossIstantiate = true;
			enemyInstatiate = false;

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

		if(Time.time > nextSpawn && enemyInstatiate ){
			nextSpawn = Time.time + spawnRate;
			GameObject g = ramdomEnemy();
			Instantiate(g,new Vector3(Random.Range(-12.75f,12.75f),0,0),g.transform.rotation);
		}


		if (audios [0].time > 21) {
			spawnRate = 10f;
		}
		if (audios [0].time > 70) {
			spawnRate = 8.0f;
		}
		if (audios [0].time > 120) {
			spawnRate = 6f;
		}
		if (audios [0].time > 180) {
			spawnRate = 25f;
		}
		if (audios [0].time > 220 && audios[0].isPlaying) {
			audios[0].Stop();
		}



		if(bossIstantiate && GameObject.FindGameObjectWithTag("Boss")== null){
			
			player = GameObject.FindWithTag("Player");
			player.GetComponent<PlayerController>().enabled = false;
			player.transform.Translate(new Vector3(0,0,speed));
			levelComplete.SetActive(true);
			if(player.transform.position.z > 21f){
				
				global.status.TotalPoints += player.GetComponent<Status>().levelPoints;
				global.status.faseAtual =1;
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
		Application.LoadLevel ("HangarScene");
	}
}