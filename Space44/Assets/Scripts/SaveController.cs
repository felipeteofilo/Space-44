using UnityEngine;
using System.Collections;

public class SaveController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void SaveGame(int slot){
		GlobalStatus global = GameObject.FindGameObjectWithTag ("Global").GetComponent<GlobalStatus> ();
		SAVEaNDLOAD.Save (global.status, slot);
		Application.LoadLevel("HangarScene");
	}
}
