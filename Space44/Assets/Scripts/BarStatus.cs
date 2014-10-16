using UnityEngine;
using System.Collections;

public class BarStatus : MonoBehaviour {
	public GameObject background;


	
	void Update(){

		background.transform.localScale = new Vector3 (1, 1, 1);
	}
}
