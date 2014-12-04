using UnityEngine;
using System.Collections;

public class GlobalStatus : MonoBehaviour {

	public SaveScript status = new SaveScript();
	public AudioSource[] a ;
	// Use this for initialization
	void Start () {
		a = GetComponents<AudioSource>();
		GameObject.DontDestroyOnLoad (gameObject);

		status.lvlDamage = 1;
		status.bullets = 1;
		status.levelButtons [1] = 1;
		status.levelButtons [4] = 1;
	
	}
	void Update(){
		if(Application.loadedLevelName.Contains("lvl")||Application.loadedLevelName.Equals("Credito")){
			a[1].Stop();
			a[0].Stop();
		}else{
			if(!a[1].isPlaying && (Application.loadedLevelName.Equals("HangarScene")|| Application.loadedLevelName.Equals("CenaUpgrade")) ){
				a[0].Stop();
				a[1].Play();

			}
			if(!a[0].isPlaying && (Application.loadedLevelName.Equals("NewGame")|| Application.loadedLevelName.Equals("CenaMenu")) ){
				a[1].Stop();
				a[0].Play();
			}

		}
		if(Application.loadedLevelName.Equals("Credito")){
			Destroy(gameObject);
		}

	}

}
