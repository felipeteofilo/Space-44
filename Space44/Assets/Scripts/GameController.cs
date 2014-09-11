using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public GameObject enemy1;
	public GameObject enemy2;
	public GameObject boss;
	public GameObject background;
	public GameObject asteroid;
	public Vector3 spawnWaves;

	[Range(0,100)]
	public int percentFirstEnemy;

	[Range(0,100 )]
	public int percentSecondEnemy;

	[Range(0,100 )]
	public int percentAsteroid;

//	public int percentThirdEnemy;
//	public int percentFourthEnemy;
	public float spawnWait;
	public float startWait;
	private float earlierX;
	private AudioSource bossSong;

	bool bossIstantiate;


	// Use this for initialization
	void Start () {
		AudioSource[] audios = GetComponents<AudioSource>();
		bossSong = audios [1];
		StartCoroutine (SpawnWaves ());
	
	}

	IEnumerator SpawnWaves(){
		yield return new WaitForSeconds(startWait);
		while(true) {
			Vector3 spawnPosition = new Vector3 (Random.Range (-spawnWaves.x, spawnWaves.x), spawnWaves.y, spawnWaves.z);

			GameObject enemy = ramdomEnemy();
			if(enemy == asteroid){
				Instantiate (enemy, spawnPosition, enemy.transform.rotation);
				spawnPosition = new Vector3 (Random.Range (-spawnWaves.x, spawnWaves.x), spawnWaves.y, spawnWaves.z);
				Instantiate (enemy, spawnPosition, enemy.transform.rotation);
				spawnPosition = new Vector3 (Random.Range (-spawnWaves.x, spawnWaves.x), spawnWaves.y, spawnWaves.z);
			}
			Instantiate (enemy, spawnPosition, enemy.transform.rotation);

			yield return new WaitForSeconds(spawnWait);
		}
	}

	GameObject ramdomEnemy(){
		float percent = Random.Range(1,100);

		if (percent <= percentAsteroid) {
			return asteroid;
		}
		else if (percent <= percentAsteroid + percentFirstEnemy) {
			return enemy1;
		}
		else if(percent <= percentAsteroid + percentFirstEnemy+ percentSecondEnemy){
			return enemy2;
		}
		return null;
				
	}

	// Update is called once per frame
	void Update () {

		if (background.transform.localPosition.z > 2.6f) {
						background.transform.Translate (background.transform.forward * -0.01f);
		} else if(!bossIstantiate){
				audio.Stop();
				bossSong.Play();
				StopAllCoroutines();
				Vector3 spawnPosition = new Vector3 (Random.Range (-spawnWaves.x, spawnWaves.x), spawnWaves.y, 30);
				Instantiate (boss, spawnPosition, boss.transform.rotation);
				bossIstantiate = true;
		}

	}
}
