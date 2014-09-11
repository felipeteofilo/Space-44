using UnityEngine;
using System.Collections;

public class HUDscript : MonoBehaviour {
	public float MaxLife =100;
	public float CurrentLife =100;
	public float tester;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		tester = 120/(MaxLife/CurrentLife);
	
	}
	void OnGUI(){
	
		GUI.Box(new Rect(930,10,120,20),""+CurrentLife);
		GUI.Box(new Rect(930,10,120/(MaxLife/CurrentLife),20),"");

		GUI.Box(new Rect(930,40,120,20),""+CurrentLife);
		GUI.Box(new Rect(930,40,120/(MaxLife/CurrentLife),20),"");

		GUI.Box(new Rect(930,70,120,20),""+CurrentLife);
		GUI.Box(new Rect(930,70,120/(MaxLife/CurrentLife),20),"");

	}
}
