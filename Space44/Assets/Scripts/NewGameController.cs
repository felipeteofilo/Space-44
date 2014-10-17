using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NewGameController : MonoBehaviour
{

		public GameObject[] spaceShips;
		private int spaceShipChose;
		public string[] names;
		public TextMesh spaceShipName;
		public Slider [] status;

		// Use this for initialization
		void Start ()
		{
				spaceShipName.text = names [spaceShipChose];
	
		}
	
		// Update is called once per frame
		void Update ()
		{

				if (Input.GetKeyDown (KeyCode.LeftArrow)) {
						spaceShipChose += 1;
						if (spaceShipChose >= spaceShips.Length / 3) {
								spaceShipChose = spaceShips.Length / 3 - 1;
						} else {
								ChangeSpaceShip (true);
						}
						spaceShipName.text = names [spaceShipChose];




				}
				if (Input.GetKeyDown (KeyCode.RightArrow)) {
						spaceShipChose -= 1;
						if (spaceShipChose < 0) {
								spaceShipChose = 0;
						} else {
								ChangeSpaceShip (false);
						}
						spaceShipName.text = names [spaceShipChose];

				}
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
