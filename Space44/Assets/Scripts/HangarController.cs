using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HangarController : MonoBehaviour
{
		GlobalStatus global ;
		public Text saveText;
		public float tempoAparecerSave;
		private float tempoAparecendo;
		// Use this for initialization
		void Start ()
		{
				global = GameObject.FindGameObjectWithTag ("Global").GetComponent<GlobalStatus> ();
	
		}
	
		// Update is called once per frame
		void Update ()
		{
				if (saveText.gameObject.activeSelf && Time.time - tempoAparecendo > tempoAparecerSave) {
						saveText.gameObject.SetActive(false);
				}


	
		}

		void Upgrade ()
		{
				Application.LoadLevel ("CenaUpgrade");
		}

		void PlayLevel ()
		{
				GlobalStatus global = GameObject.FindGameObjectWithTag ("Global").GetComponent<GlobalStatus> ();
				if (global != null) {
						Application.LoadLevel ("lvl" + global.status.faseAtual);
				} else {
						Application.LoadLevel ("lvl1");
				}
		}

		void MainMenu ()
		{

				Application.LoadLevel ("CenaMenu");

		}

		void Save ()
		{

				SAVEaNDLOAD.Save (global.status, 0);
		saveText.gameObject.SetActive(true);
				tempoAparecendo = Time.time;
		}
}
