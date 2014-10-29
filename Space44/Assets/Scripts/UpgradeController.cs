using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;

public class UpgradeController : MonoBehaviour
{

		public GameObject[] spaceShips;
		public int spaceShipChose;
		public string[] names;
		public TextMesh spaceShipName;
		public Slider[] status;
		private GlobalStatus global;
		public Button[] buttons;


	
	
		// Use this for initialization
		void Start ()
		{


				global = GameObject.FindGameObjectWithTag ("Global").GetComponent<GlobalStatus> ();
				if (global != null) {
						spaceShipChose = global.status.nave;
				}
				spaceShipName.text = names [spaceShipChose];

				for (int i = 0; i < spaceShipChose; i++) {
						ShowSpaceShip ();
				}
		ShowButtons ();

		}

		void ShowButtons ()
		{



				for (int i = 0; i< buttons.Length; i++) {
						int ID = buttons [i].GetComponent<UpgradeButton> ().ID;

						Sprite image = Resources.Load<Sprite> ("upgrade" + global.status.levelButtons [ID]);
						buttons [i].image.sprite = image;

				}



		}

		void Back ()
		{

				Application.LoadLevel ("HangarScene");


		}
	
		// Update is called once per frame
		void Update ()
		{
				if (spaceShips [spaceShipChose + 8].GetComponent<Status> ()) {

						Status shipStatus = spaceShips [spaceShipChose + 8].GetComponent<Status> ();
						status [0].value = shipStatus.damage;
						status [1].value = shipStatus.MaxLife;
						status [2].value = shipStatus.speed;
						status [3].value = shipStatus.stability;
				}
		}

		public void Highlight (Button button)
		{

				string imageName = button.image.sprite.name.Substring (7, 1);
	
				int number = int.Parse (imageName);
				if (number < 4) {
						Sprite image = Resources.Load<Sprite> ("upgrade" + (number + 1));
						button.image.sprite = image;
				}
		}

		public void Buy (Button button)
		{
				string imageName = button.image.sprite.name.Substring (7, 1);
		
				int number = int.Parse (imageName);
				if (number < 4) {
		
						if (button.name == "NumberOfShoots" || button.name == "SpecialEnergy") {
								if (number == 3)
										return;
						}
						Highlight (button);
						button.GetComponent<UpgradeButton> ().Buy (global);
				}
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
