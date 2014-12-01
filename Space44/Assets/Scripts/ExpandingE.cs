using UnityEngine;
using System.Collections;

public class ExpandingE : MonoBehaviour {

	public float growingSpeed;
	private float atual =0;
	public float limit;
	private float dmg = 2;

	// Use this for initialization
	void Start () {
		renderer.material.color = new Color (renderer.material.color.r,
		                                   renderer.material.color.g,
		                                   renderer.material.color.b,
		                                   0.25f);
	}
	
	// Update is called once per frame
	void Update () {
		transform.localPosition = new Vector3(0,0,0);
		if(atual < limit){
		transform.localScale += new Vector3(growingSpeed,0,growingSpeed);
		atual += growingSpeed;

		}

	}
	void OnTriggerStay(Collider c){

		if(c.tag == "Player" ){
			c.SendMessageUpwards("AplyDamage",dmg);
		}


	}
}
