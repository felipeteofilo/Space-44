using UnityEngine;
using System.Collections;

public class Loading : MonoBehaviour {
	GlobalStatus g;
	public GameObject[] buttons;
	public GameObject[] imagem;
	void Start(){
		 g = GameObject.FindGameObjectWithTag ("Global").GetComponent<GlobalStatus> ();
	}

	void Update () {
		if(g.status.faseAtual >=2){
			buttons[1].SetActive(true);
			imagem[0].GetComponent<SpriteRenderer>().color = new Color(1,1,1);
		}
		if(g.status.faseAtual >=3){
			buttons[2].SetActive(true);
			imagem[1].GetComponent<SpriteRenderer>().color = new Color(1,1,1);
		}
		if(g.status.faseAtual >=4){
			buttons[3].SetActive(true);
			imagem[2].GetComponent<SpriteRenderer>().color = new Color(1,1,1);
		}
	}
	public void Load(int i){
		Application.LoadLevel("lvl"+i);
	}
	public void Back (){
		Application.LoadLevel("HangarScene");
	}
}
