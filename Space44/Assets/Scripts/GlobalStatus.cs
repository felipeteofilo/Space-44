using UnityEngine;
using System.Collections;

public class GlobalStatus : MonoBehaviour {

	public SaveScript status = new SaveScript();

	// Use this for initialization
	void Start () {

		GameObject.DontDestroyOnLoad (gameObject);
	
	}
	

}
