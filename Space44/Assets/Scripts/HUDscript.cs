using UnityEngine;
using System.Collections;

public class HUDscript : MonoBehaviour {
	private Status status;

	float MaxLife;
public	float CurrentLife;
	public float MaxSpecial;
	public float CurrentSpecial;
	public float MaxShield;
	public float CurrentShield;

	public int levelPoints;
	bool onTurn = false;
	float tester;
	float width;
	// Use this for initialization
	void Start () {
		/*
		width = Screen.width;


		MaxLife = status.MaxLife;
		MaxSpecial = status.timeSpecific;
		MaxShield = status.timeShield;*/
	
	}
	
	// Update is called once per frame
	void Update () {
		if (status == null) {
			if(GameObject.FindGameObjectWithTag ("Player")!= null){
						status = GameObject.FindGameObjectWithTag ("Player").GetComponent<Status> ();
			}				} else {			
						CurrentLife = status.life;
						CurrentSpecial = status.actualSpecificTime;
						CurrentShield = status.actualShieldTime;
						levelPoints = status.levelPoints;
						MaxLife = status.MaxLife;
						MaxSpecial = status.timeSpecific;
						MaxShield = status.timeShield;
				}	
		
		width = Screen.width;
		//Pegar Status do Jogador e setar nas tretas
		
	}
	void OnGUI(){
				if (status != null) {
			onTurn = true;}
		if(onTurn){
			GUI.color = Color.white;
			//Vida
			GUI.TextArea (new Rect (0.86f * width, 0, 0.13f * width, 20), "Life");
			GUI.Box (new Rect (0.86f * width, 20, 0.13f * width, 20), "" + (int)CurrentLife);
			GUI.Box (new Rect (0.86f * width, 20, (0.13f * width) / (MaxLife / CurrentLife), 20), "");
			//Laser
			GUI.TextArea (new Rect (0.86f * width, 45, 0.13f * width, 20), "Special");
			GUI.Box (new Rect (0.86f * width, 65, 0.13f * width, 20), "" + (int)CurrentSpecial);
			GUI.Box (new Rect (0.86f * width, 65, (0.13f * width) / (MaxSpecial / CurrentSpecial), 20), "");
			//Escudo
			GUI.TextArea (new Rect (0.86f * width, 90, 0.13f * width, 20), "Shield");
			GUI.Box (new Rect (0.86f * width, 110, 0.13f * width, 20), "" + (int)CurrentShield);
			GUI.Box (new Rect (0.86f * width, 110, (0.13f * width) / (MaxShield / CurrentShield), 20), "");
			//Pontos
			GUI.TextArea (new Rect (0.86f * width, 135, 0.13f * width, 20), "Points");
			GUI.Box (new Rect (0.86f * width, 155, 0.13f * width, 20), "" + levelPoints);
			
			GUI.Box (new Rect (0.86f * width, 200, 0.13f * width, 20), "Time: " + (int)(Time.timeSinceLevelLoad / 60) + ":" + (int)(Time.timeSinceLevelLoad % 60));

		}

		
		
	}
}
