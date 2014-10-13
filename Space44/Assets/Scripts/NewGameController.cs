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
						else{
							ChangeSpaceShip(true);
						}



				}
				if (Input.GetKeyDown (KeyCode.RightArrow)) {
						spaceShipChose -= 1;
						if (spaceShipChose < 0) {
								spaceShipChose = 0;
						}
				}
	}

	void ChangeSpaceShip(bool left){

		if(left){
			for(int i = 0; i< spaceShips.Length;i++){
				float x = spaceShips[i].transform.position.x;
				float y = spaceShips[i].transform.position.y;
				float z;
				x -=0.7f;
				if(i  == spaceShipChose){
					z = -0.6f;
					

				}
				else{
					z = 0f;
				}

				Debug.Log(z);
				spaceShips[i].transform.position = new Vector3(x,y,z);
			}
		}

		

	}
}
