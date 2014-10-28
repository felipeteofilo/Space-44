using UnityEngine;
using System.Collections;

public class Father : MonoBehaviour {
	public int DeathCounter;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(transform.childCount  == DeathCounter){
			Destroy(gameObject);
		}

		}
	}

