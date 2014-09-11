using UnityEngine;
using System.Collections;

public class ColliderBoss : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnParticleCollision(GameObject others){
		//conferir as particulas
		//setar dmg
		if(others.tag != "BossBullet" || others.tag != "BossLaser"){
			if(others.tag == "BasicPlayerShoot")
				SendMessageUpwards("AplyDamage",1);
			if(others.tag == "PlayerLaser")
				SendMessageUpwards("AplyDamage",0.2f);
		}

	}
}
