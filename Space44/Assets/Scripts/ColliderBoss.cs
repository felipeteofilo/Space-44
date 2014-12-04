using UnityEngine;
using System.Collections;

public class ColliderBoss : MonoBehaviour {

	private float timeNextFlash;
	private float timeToFlash = 0.2f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnParticleCollision(GameObject others){
		//conferir as particulas
		//setar dmg
		if (Time.time > timeNextFlash && this.gameObject.collider.enabled == true) {
			timeNextFlash = Time.time + timeToFlash;
			StartCoroutine (FlashPlayer (0.03f));

		}

		if(others.tag != "BossBullet" || others.tag != "BossLaser"){
			if(others.tag == "BasicPlayerShoot")
				SendMessageUpwards("AplyDamage",DamageController.shootList[0].damage);
			if(others.tag == "PlayerLaser")
				SendMessageUpwards("AplyDamage",DamageController.shootList[2].damage);
		}

	}
	IEnumerator FlashPlayer (float intervalTime)
	{
		
		float elapsedTime = 0f;
		float time = Time.deltaTime;
		Color color = new Color(0,0,0); 
		
		Transform rendererBoss = transform;
		color = rendererBoss.renderer.material.color;

		while (elapsedTime < time) {
			if (rendererBoss != null) {
				rendererBoss.renderer.material.color = new Color (255,255,255);
			}
			elapsedTime += Time.deltaTime;
			yield return new WaitForSeconds (intervalTime);
		}
		if (rendererBoss != null) {
			rendererBoss.renderer.material.color = color;
		}
	}
	void PiscaAe(float t){
		if (Time.time > timeNextFlash && this.gameObject.collider.enabled == true) {
			timeNextFlash = Time.time + timeToFlash;
			StartCoroutine (FlashPlayer (t));
		}
	}

}
