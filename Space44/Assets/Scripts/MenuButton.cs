using UnityEngine;
using System.Collections;

public class MenuButton : MonoBehaviour {

	public int ID;
	private Menu menu;

	void Start(){

		menu = GameObject.FindObjectOfType<Menu>();

	}

	void OnMouseEnter(){

		menu.menuChose = ID;
	}

	void OnMouseDown(){
		menu.ChoseOption ();
	}
	

}
