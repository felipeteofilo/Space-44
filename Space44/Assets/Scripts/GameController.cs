using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public GameObject hazard;
	public Vector3 spawnWaves;
	public int hazardCount;
	public int hazardEnemyPerTime;
	public float spawnWait;
	public float startWait;
	private float earlierX;
	// Use this for initialization
	void Start () {

		StartCoroutine (SpawnWaves ());
	
	}

	IEnumerator SpawnWaves(){
		yield return new WaitForSeconds(startWait);
		for (int i = 0; i < hazardCount; i++) {
			for(int j = 0; j < hazardEnemyPerTime; j++){
				Vector3 spawnPosition = new Vector3 (Random.Range (-spawnWaves.x, spawnWaves.x), spawnWaves.y, spawnWaves.z);

				while((spawnPosition.x - earlierX < 20 || spawnPosition.x - earlierX > -20) && earlierX == spawnPosition.x ){
					spawnPosition = new Vector3 (Random.Range (-spawnWaves.x, spawnWaves.x), spawnWaves.y, spawnWaves.z);
				}

				earlierX = spawnPosition.x;
				Instantiate (hazard, spawnPosition, hazard.transform.rotation);
			}

			if(i == hazardCount -1){
				i=0;
			}
			yield return new WaitForSeconds(spawnWait);
		}
	}

	// Update is called once per frame
	void Update () {
	
	}
}
