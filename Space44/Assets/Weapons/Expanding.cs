using UnityEngine;
using System.Collections;

public class Expanding : MonoBehaviour {

	public float growingSpeed;
	private float atual =0;
	public float limit;
	private float dmg;
	public Vector3 OriginalSize;

	// Use this for initialization
	void Start () {
		renderer.material.color = new Color (renderer.material.color.r,
		                                   renderer.material.color.g,
		                                   renderer.material.color.b,
		                                   0.25f);
		OriginalSize = transform.localScale;

	}
	
	// Update is called once per frame
	void Update () {

		if(atual < limit){
		transform.localScale += new Vector3(growingSpeed,0,growingSpeed);
		atual += growingSpeed;

		}
		else {
			gameObject.SetActive(false);
			 transform.localScale = OriginalSize;
			atual = 0;

		}
	}
	void OnCollisionEnter(Collision c){

		if(c.transform.tag != "Player" ){
			 
			c.transform.SendMessageUpwards("AplyDamage",dmg);
		}

	}
	void setdmg(float DMG){
		dmg = DMG;

	}
}
