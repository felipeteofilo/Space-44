using UnityEngine;
using System.Collections;

public class Creditos : MonoBehaviour {
	public GameObject creditos;
	public float fim;
	public float speed;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		creditos.transform.Translate(new Vector3(0,speed,0));
		if(creditos.transform.localPosition.y > fim){
			BackToMenu();
		}
	}
	public void BackToMenu(){
		Application.LoadLevel("CenaMenu");
	}
}
