using UnityEngine;
using System.Collections;

public class MonitorController : MonoBehaviour {

	public GameObject[] Slot1;
	public GameObject[] Slot2;
	public GameObject[] Slot3;
	public GameObject[] Slot4;



	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		for(int i =0;i<4;i++){
			SaveScript s = SAVEaNDLOAD.Load(i);
			if(s !=null){

				if(i == 0){
					Slot1[s.nave].SetActive(true);
					for(int j = 0;j<4;j++){
						if(j != s.nave){
							Slot1[j].SetActive(false);
						}
					}
				}
				if(i == 1){
					Slot2[s.nave].SetActive(true);
					for(int j = 0;j<4;j++){
						if(j != s.nave){
							Slot2[j].SetActive(false);
						}
					}
				}
				if(i == 2){
					Slot3[s.nave].SetActive(true);
					for(int j = 0;j<4;j++){
						if(j != s.nave){
							Slot3[j].SetActive(false);
						}
					}
				}
				if(i == 3){
					Slot4[s.nave].SetActive(true);
					for(int j = 0;j<4;j++){
						if(j != s.nave){
							Slot4[j].SetActive(false);
						}
					}
				}
			}

		}


	}
}
