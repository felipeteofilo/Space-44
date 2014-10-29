﻿using UnityEngine;
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
		Load (0);
		saves[p]=s;
		BinaryFormatter bf = new BinaryFormatter();
		FileStream file = File.Create (Application.persistentDataPath + "/savedGames.gd");
		bf.Serialize(file, saves);
		file.Close();


	}
	public static SaveScript Load(int p){
		if(File.Exists(Application.persistentDataPath + "/savedGames.gd")) {
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open(Application.persistentDataPath + "/savedGames.gd", FileMode.Open);
			saves = (SaveScript[])bf.Deserialize(file);
			file.Close();
			return saves[p];
		}
		return null;
}


}