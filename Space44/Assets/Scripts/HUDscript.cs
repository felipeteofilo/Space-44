using UnityEngine;
using System.Collections;

public class HUDscript : MonoBehaviour {
	private Status status;

	float MaxLife;
public	float CurrentLife;
	float MaxSpecial;
	float CurrentSpecial;
	float MaxShield;
	float CurrentShield;

	int levelPoints;
	
	float tester;
	float width;
	// Use this for initialization
	void Start () {
		
		width = Screen.width;


		MaxLife = status.MaxLife;
		MaxSpecial = status.timeSpecific;
		MaxShield = status.timeShield;
	
	}
	
	// Update is called once per frame
	void Update () {
		if (status == null) {
						status = GameObject.FindGameObjectWithTag ("Player").GetComponent<Status> ();
				} else {			
						CurrentLife = status.life;
						CurrentSpecial = status.actualSpecificTime;
						CurrentShield = status.actualShieldTime;
						levelPoints = status.levelPoints;
				}	
		
		width = Screen.width;
		//Pegar Status do Jogador e setar nas tretas
		
	}
	void OnGUI(){
				if (status != null) {
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
