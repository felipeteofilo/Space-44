using UnityEngine;
using System.Collections;

public class HUDscript : MonoBehaviour {
	public float MaxLife =100;
	public float CurrentLife =100;
	public float MaxSpecial =100;
	public float CurrentSpecial =100;
	public float MaxShield =100;
	public float CurrentShield =100;
	
	public float tester;
	public float width;
	// Use this for initialization
	void Start () {
		
		width = Screen.width;
		
	}
	
	// Update is called once per frame
	void Update () {
		tester = 120/(MaxLife/CurrentLife);
		
		width = Screen.width;
		//Pegar Status do Jogador e setar nas tretas
		
	}
	void OnGUI(){
		GUI.color = Color.white;
		//Vida
		GUI.Box(new Rect(0.86f*width,10,0.13f*width,20),""+CurrentLife);
		GUI.Box(new Rect(0.86f*width,10,(0.13f*width)/(MaxLife/CurrentLife),20),"");
		//Laser
		GUI.Box(new Rect(0.86f*width,35,0.13f*width,20),""+CurrentSpecial);
		GUI.Box(new Rect(0.86f*width,35,(0.13f*width)/(MaxSpecial/CurrentSpecial),20),"");
		//Escudo
		GUI.Box(new Rect(0.86f*width,60,0.13f*width,20),""+CurrentShield);
		GUI.Box(new Rect(0.86f*width,60,(0.13f*width)/(MaxShield/CurrentShield),20),"");
		
		
	}
}
