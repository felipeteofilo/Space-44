using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;



public class SAVEaNDLOAD : MonoBehaviour {

	public static SaveScript[] saves = new SaveScript[4] ;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public static void Save(SaveScript s,int p){
		saves[p]=s;
		BinaryFormatter bf = new BinaryFormatter();
		FileStream file = File.Create (Application.persistentDataPath + "/savedGames.gd");
		Debug.Log (Application.persistentDataPath + "/savedGames.gd");
		bf.Serialize(file, saves);
		file.Close();


	}
	public static void Load(){
		if(File.Exists(Application.persistentDataPath + "/savedGames.gd")) {
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open(Application.persistentDataPath + "/savedGames.gd", FileMode.Open);
			saves = (SaveScript[])bf.Deserialize(file);
			file.Close();


		
	}
}
}