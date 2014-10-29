using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{
		public GUIText restart;
		public GameObject enemy1;
		public GameObject enemy2;
		public GameObject boss;
		public GameObject background;
		public GameObject background2;
		public GameObject asteroid;
		public Vector3 spawnWaves;
		[Range(0,100)]
		public int
				percentFirstEnemy;
		[Range(0,100 )]
		public int
				percentSecondEnemy;
		[Range(0,100 )]
		public int
				percentAsteroid;

//	public int percentThirdEnemy;
//	public int percentFourthEnemy;
		public float spawnWait;
		public float startWait;
		private float earlierX;
		private AudioSource bossSong;
		bool bossIstantiate;
	AudioSource[] audios ;
	public int s;
	public GameObject[] players = new GameObject[4];
	public GameObject planetas ;


		// Use this for initialization
		void Start ()
		{
	if (SAVEaNDLOAD.Load (0).nave != null) {
						s = SAVEaNDLOAD.Load (0).nave;
				}

				 audios = GetComponents<AudioSource> ();
				audios[s].Play();
				bossSong = audios [4];
				StartCoroutine (SpawnWaves ());
				Instantiate(players[s],new Vector3(0,0,1),Quaternion.Euler(new Vector3(0,0,0)));

	
		}

		IEnumerator SpawnWaves ()
		{
				yield return new WaitForSeconds (startWait);
				while (true) {
						Vector3 spawnPosition = new Vector3 (Random.Range (-spawnWaves.x, spawnWaves.x), spawnWaves.y, spawnWaves.z);

						GameObject enemy = ramdomEnemy ();
						if (enemy == asteroid) {
								Instantiate (enemy, spawnPosition, enemy.transform.rotation);
								spawnPosition = new Vector3 (Random.Range (-spawnWaves.x, spawnWaves.x), spawnWaves.y, spawnWaves.z);
								Instantiate (enemy, spawnPosition, enemy.transform.rotation);
								spawnPosition = new Vector3 (Random.Range (-spawnWaves.x, spawnWaves.x), spawnWaves.y, spawnWaves.z);
						}
						Instantiate (enemy, spawnPosition, enemy.transform.rotation);

						yield return new WaitForSeconds (spawnWait);
				}
		}

		GameObject ramdomEnemy ()
		{
				float percent = Random.Range (1, 100);

				if (percent <= percentAsteroid) {
						return asteroid;
				} else if (percent <= percentAsteroid + percentFirstEnemy) {
						return enemy1;
				} else if (percent <= percentAsteroid + percentFirstEnemy + percentSecondEnemy) {
						return enemy2;
				}
				return null;
				
		}
		
		void FixedUpdate ()
		{
				if (background.transform.localPosition.z > 2.6f) {
						background.transform.Translate (background.transform.forward * -0.05f);
						background2.transform.Translate (background2.transform.forward * 0.025f);
						//planetas.transform.Translate (background.transform.forward * -0.025f);
				} else if (!bossIstantiate) {
						audios[s].Stop();
						bossSong.Play ();
						StopAllCoroutines ();
						ParticleSystem[] stars = GameObject.FindGameObjectWithTag ("Stars").GetComponentsInChildren<ParticleSystem> ();
						for (int i =0; i< stars.Length; i++) {
								stars [i].Pause ();
						}
						Vector3 spawnPosition = new Vector3 (Random.Range (-spawnWaves.x, spawnWaves.x), spawnWaves.y, 30);
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
		if(bossIstantiate && GameObject.FindGameObjectWithTag("Boss")== null){
			Application.LoadLevel("lvl2");
			
		}
		}
}
