using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LoadController : MonoBehaviour {

	public Button[] buttons;

	// Use this for initialization
	void Start () {
//		for(){
//		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void Load(int slot){

		GlobalStatus global = GameObject.FindGameObjectWithTag ("Global").GetComponent<GlobalStatus> ();
		global.status = SAVEaNDLOAD.Load (slot);
		if (global.status != null) {
			Application.LoadLevel ("HangarScene");
		}
	}
	public void Back(){
		Application.LoadLevel ("CenaMenu");
	}








}
