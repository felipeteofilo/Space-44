using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour
{

		
		void NewGame(){
		Application.LoadLevel("NewGame");
		}
	void Load(){

		Application.LoadLevel ("LoadScene");
				
	}
	void Credits(){

		Application.LoadLevel ("Credito");

		}
	void Exit(){
		Application.Quit ();
	}
}
