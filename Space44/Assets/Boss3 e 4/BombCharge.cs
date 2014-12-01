using UnityEngine;
using System.Collections;

public class BombCharge : MonoBehaviour {
	public float limit;
	// Use this for initialization
	void Start () {

	GameObject g =GameObject.FindGameObjectWithTag("Player");
		if(g!=null){
		transform.LookAt(g.transform.position);
		}
		}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(new Vector3(0,0,0.1f));
		if(transform.position.z < limit){
			Destroy(gameObject);
		}
	}
	void OnCollisionEnter (Collision collision){
		if(collision.transform.tag =="Player"){
			collision.transform.SendMessageUpwards("AplyDamage",5f);
			Destroy (this.gameObject);
		}
	} 
}
