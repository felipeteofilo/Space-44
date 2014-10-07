using UnityEngine;
using System.Collections;

public class Rastreador : MonoBehaviour {
	public GameObject[] enemies;
	private GameObject target;
	public GameObject pai;
	public GameObject explosion;
	public float speed;
	public float dmg;//pegar do status


	// Use this for initialization
	void Start () {
		if(GameObject.FindGameObjectsWithTag("Enemy")!= null){
		enemies = GameObject.FindGameObjectsWithTag("Enemy");
			target = enemies[0];
			Debug.Log("caiu aki");
		if(GameObject.FindGameObjectWithTag("Boss")!= null){
			enemies[enemies.Length] =GameObject.FindGameObjectWithTag("Boss");
		}
		if(enemies.Length >1){
		for(int i=1;i<enemies.Length;i++){
			if(Vector3.Distance(gameObject.transform.position,target.transform.position)>
				   Vector3.Distance(gameObject.transform.position,enemies[i].transform.position)){
				target = enemies[i];
			
				}
			}
			}
		}
		if(GameObject.FindGameObjectWithTag("Boss")!= null){
			enemies[0] = GameObject.FindGameObjectWithTag("Boss");
			target = enemies[0];
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(target != null && target.activeSelf){
		pai.transform.LookAt(target.transform);
		//transform.rotation.eulerAngles = Quaternion(new Vector3(0,transform.rotation.y,0));
		pai.transform.Translate(new Vector3(0,0,speed));
		}
		else{
			pai.transform.Translate(new Vector3(0,0,speed));
			Start();
		}
	}
	void OnTriggerEnter(Collider c){

		if(c.tag == "Enemy" || c.tag == "Boss" ){
			c.SendMessageUpwards("Aplydamage",dmg);
		//	Instantiate(explosion,transform.position,transform.rotation);
			Destroy(pai);


		}

	}
}
