using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HUDscript : MonoBehaviour {
	private Status status;

	float MaxLife;
public	float CurrentLife;
	public float MaxSpecial;
	public float CurrentSpecial;
	public float MaxShield;
	public float CurrentShield;

	public Slider[] Hud;
	public Text Pontos;
	public int levelPoints;



	// Use this for initialization
	void Start () {

	
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

		Hud[0].maxValue = MaxLife;
		Hud[0].value = CurrentLife;

		Hud[1].maxValue = MaxShield;
		Hud[1].value = MaxShield - CurrentShield;

		Hud[2].maxValue = MaxSpecial;
		Hud[2].value = MaxSpecial - CurrentSpecial;

		Pontos.text ="" + levelPoints;

		
	}

}
