using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NewGameController : MonoBehaviour
{

		public GameObject[] spaceShips;
		private int spaceShipChose;
		public string[] names;
		public TextMesh spaceShipName;
		public Slider[] status;
		public Button next;
		public Button previous;
		
		

		// Use this for initialization
		void Start ()
		{
				spaceShipName.text = names [spaceShipChose];
	
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

				if (spaceShipChose >= spaceShips.Length / 3 - 1) {
						previous.interactable = false;

				} else if (spaceShipChose <= 0) {
						next.interactable = false;
				}
				
		}

	void Status(){
		GlobalStatus global = GameObject.FindGameObjectWithTag("Global").GetComponent<GlobalStatus>();

		if (spaceShips [spaceShipChose +8].GetComponent<Status> ()) {
			
			Status shipStatus = spaceShips [spaceShipChose + 8].GetComponent<Status> ();
			global.status.lvlDamage = shipStatus.lvlDamage;
			global.status.BonusLife = shipStatus.BonusLife;
			global.status.BonusRate = shipStatus.bonusRate;
			global.status.BonusShield =shipStatus.bonusTimeShield;
			global.status.BonusSpecific = shipStatus.bonusSpecific;
			global.status.BonusSpeed = shipStatus.BonusSpeed;
			global.status.BonusStability = shipStatus.BonusStabilty;
			global.status.bullets = shipStatus.bullets;
			global.status.nave = spaceShipChose;
			global.status.faseAtual = 1;
		}


		}

		void Choose(){
		Status ();
		Application.LoadLevel("HangarScene");

		}
		
		void PreviousSpaceShip ()
		{
				spaceShipChose += 1;
				if (spaceShipChose >= spaceShips.Length / 3) {
						spaceShipChose = spaceShips.Length / 3 - 1;
						
				} else {
						next.interactable = true;
						ChangeSpaceShip (true);
				}
				spaceShipName.text = names [spaceShipChose];
		}

		void NextSpaceShip ()
		{
				spaceShipChose -= 1;
				if (spaceShipChose < 0) {
						spaceShipChose = 0;
						
				} else {
						previous.interactable = true;
						
						ChangeSpaceShip (false);
				}
				spaceShipName.text = names [spaceShipChose];
		}

		void ChangeSpaceShip (bool left)
		{
				for (int i = 0; i< spaceShips.Length; i++) {
						float x = spaceShips [i].transform.position.x;
						float y = spaceShips [i].transform.position.y;
						float z = spaceShips [i].transform.position.z;
						
						if (left) {
								x -= 5.5f;
						} else {
								x += 5.5f;
						}
						spaceShips [i].transform.position = new Vector3 (x, y, z);
				}
		}
}
