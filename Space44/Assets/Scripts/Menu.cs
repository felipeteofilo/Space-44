using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour
{

		
		void NewGame(){
		Application.LoadLevel("NewGame");
		}
	void Load(){

		GlobalStatus global = GameObject.FindGameObjectWithTag ("Global").GetComponent<GlobalStatus> ();
		global.status = SAVEaNDLOAD.Load (0);

		Application.LoadLevel("HangarScene");
	}
	void Credits(){

		Debug.Log("Creditos");

		}
	void Exit(){
		Application.Quit ();
	}
}
