using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour
{

		public TextMesh[] buttons;
		public int menuChose;
		



		// Use this for initialization
		void Start ()
		{


	
		}
	
		// Update is called once per frame
		void Update ()
		{

				if (Input.GetKeyDown (KeyCode.DownArrow)) {
						menuChose += 1;
						if (menuChose > 3) {
								menuChose = 0;
						}
				} else if (Input.GetKeyDown (KeyCode.UpArrow)) {
						menuChose -= 1;
						if (menuChose < 0) {
								menuChose = buttons.Length - 1;
						}
				}


				for (int i = 0; i < buttons.Length; i++) {
						if (menuChose == i) {
								buttons [i].renderer.material.color = Color.black;
						} else {
								buttons [i].renderer.material.color = Color.white;
						}
				}
				if (Input.GetKeyDown (KeyCode.Return)) {
						ChoseOption ();
				}
	
		}

		public void ChoseOption ()
		{

				switch (menuChose) {
				case 0:
						Debug.Log ("new game");
						break;
				case 1:
						Debug.Log ("load");
						break;
				case 2:
						Debug.Log ("credits");
						break;
				case 3:
						Debug.Log ("exit");
						break;

				}
		}
}
