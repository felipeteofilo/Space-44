﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;

public class UpgradeController : MonoBehaviour {

	public GameObject[] spaceShips;
	private int spaceShipChose;
	public string[] names;
	public TextMesh spaceShipName;
	public Slider[] status;
	public Button [] buttons;
	public Sprite text;
	public EventSystem eventSystem;
	
	
	// Use this for initialization
	void Start ()
	{
		spaceShipName.text = names [spaceShipChose];

		if (PlayerPrefs.HasKey("NaveEscolhida")) {
			spaceShipChose = PlayerPrefs.GetInt ("NaveEscolhida");
		}

		for (int i = 0; i < spaceShipChose; i++) {
			ShowSpaceShip();
				}

	}
	
	// Update is called once per frame
	void Update ()
	{
		if (spaceShips [spaceShipChose +8].GetComponent<Status> ()) {

			Status shipStatus = spaceShips [spaceShipChose + 8].GetComponent<Status> ();
			status [0].value = shipStatus.damage;
			status [1].value = shipStatus.MaxLife;
			status [2].value = shipStatus.speed;
			status [3].value = shipStatus.stability;
		}
	}


	public void Highlight(Button button){

		string imageName = button.image.sprite.name.Substring(7,1);
	
		int number = int.Parse(imageName);
		if (number < 4) {
			Sprite image = Resources.Load<Sprite> ("upgrade" + (number + 1));
			button.image.sprite = image;
		}
	}
	public void ExitHighlight(Button button){
		
		string imageName = button.image.sprite.name.Substring(7,1);

		int number = int.Parse(imageName);
		if (number >= 1) {
			Sprite image = Resources.Load<Sprite> ("upgrade" + (number - 1));
			button.image.sprite = image;
		}
	}

	public void Buy(Button button){
		Debug.Log("foi");
	}


	void ShowSpaceShip ()
	{
		for (int i = 0; i< spaceShips.Length; i++) {
			float x = spaceShips [i].transform.position.x;
			float y = spaceShips [i].transform.position.y;
			float z = spaceShips [i].transform.position.z;

			x -= 5.5f;

			spaceShips [i].transform.position = new Vector3 (x, y, z);
		}
	}
}
