using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public GameObject enemy1;
	public GameObject enemy2;
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


	// Use this for initialization
	void Start () {

		StartCoroutine (SpawnWaves ());
	
	}

	IEnumerator SpawnWaves(){
		yield return new WaitForSeconds(startWait);
		while(true) {
			Vector3 spawnPosition = new Vector3 (Random.Range (-spawnWaves.x, spawnWaves.x), spawnWaves.y, spawnWaves.z);

			GameObject enemy = ramdomEnemy();

			Instantiate (enemy, spawnPosition, enemy.transform.rotation);

			yield return new WaitForSeconds(spawnWait);
		}
	}

	GameObject ramdomEnemy(){
		float percent = Random.Range(1,100);

		if (percent <= percentAsteroid) {
			return asteroid;
		}
		if (percent <= percentFirstEnemy) {
			return enemy1;
		}
		else {
			return enemy2;
		}

				
	}

	// Update is called once per frame
	void Update () {
	
	}
}
