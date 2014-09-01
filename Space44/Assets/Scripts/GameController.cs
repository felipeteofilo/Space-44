using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public GameObject hazard;
	// Use this for initialization
	void Start () {
	
	}

	void SpawnWaves(){
		Vector3 spawnPosition = new Vector3 ();
		Quaternion spawnRotation = new Quaternion ();
		Instantiate (hazard, spawnPosition, spawnRotation);
		}

	// Update is called once per frame
	void Update () {
	
	}
}
