using UnityEngine;
using System.Collections;

public class NewGameController : MonoBehaviour
{

		public GameObject[] spaceShips;
		private int spaceShipChose;

		// Use this for initialization
		void Start ()
		{
	
		}
	
		// Update is called once per frame
		void Update ()
		{

				if (Input.GetKeyDown (KeyCode.LeftArrow)) {
						spaceShipChose += 1;
						if (spaceShipChose >= spaceShips.Length) {
								spaceShipChose = spaceShips.Length - 1;
						}

				}
				if (Input.GetKeyDown (KeyCode.RightArrow)) {
						spaceShipChose -= 1;
						if (spaceShipChose < 0) {
								spaceShipChose = 0;
						}
				}
	}
}
