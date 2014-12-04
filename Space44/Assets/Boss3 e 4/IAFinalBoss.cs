using UnityEngine;
using System.Collections;

public class IAFinalBoss : MonoBehaviour {
	public float HpMax;
	public float HpAtual;
	private float nextCure;
	public float CureRate;
	private float Recovery;

	public ParticleSystem[] bullets;
	int b =0;
	private float nextFire;
	public float FireRate;

	private float nextChange;
	public float ChangeRate;

	private float nextRot;
	public float RotRate;

	private bool OnDie;

	public ParticleSystem[] lasers;
	private int L =0;
	private bool alfaMode = true;
	private bool betaMode = true;
	public float ModeRate;
	private float nextMode;
	public GameObject biglaser;

	public GameObject[] spawns;
	private float nextbomb;
	public float bombRate;
	public GameObject[] Bombs;

	public float startPosition;
	public float speed;
	public GameObject explosion;
	public GameObject[] SpotsOfExplosion;
	bool ThreadOn = false;
	bool allExplosions = false;
	Vector3 Dieposition;

	
	public enum Mode{
		Begin,
		ModeA,
		ModeB,
		Death
	}
	public Mode m = Mode.Begin;
	private GameObject target;
	// Use this for initialization
	void Start () {
		HpAtual = HpMax;
		Recovery = (HpMax/100) *0.25f;
		nextChange = Time.time + ChangeRate;
		Dieposition = transform.position;
		nextMode = Time.time + ModeRate;
	}
	
	// Update is called once per frame
	void Update () {
		target = GameObject.FindGameObjectWithTag("Player");
		LifeController();
		if(m == Mode.ModeA){
			AlfaMode();
		}
		if(m == Mode.ModeB){
			BetaMode();
		}
		if(Time.time > nextChange){
			if(m == Mode.ModeA){
				m = Mode.ModeB;
			}else if(m == Mode.ModeB){
				m = Mode.ModeA;
			}
			nextChange = Time.time + ChangeRate;
		}
	}
	void FixedUpdate(){
		if(transform.position.z>startPosition && m != Mode.Death){
		transform.Translate (new Vector3 (0, 0, -speed));
		}else{
			if(m == Mode.Begin){
			m = Mode.ModeA;
			}
		}
		if(m == Mode.Death && allExplosions ){
			transform.Translate (new Vector3 (0, 0, speed));
			if(transform.position.z > Dieposition.z){
				Destroy(gameObject);
			}
		}
	}
	void AlfaMode(){

		if(alfaMode){
			for(int i = 0; i<lasers.Length;i++){
				lasers[i].enableEmission = false;
			}
		if(Time.time > nextFire){
			if(b == 0){
		for(int i = 0; i<bullets.Length/2;i++){
				bullets[i].Emit(1);
			}
			nextFire = Time.time + FireRate;
				b = 1;
			}else{
				for(int i = 4; i<bullets.Length;i++){
					bullets[i].Emit(1);
				}
				b = 0;
				nextFire = Time.time + FireRate;
			}
			}
		}else{
		if(Time.time > nextRot){
			if(L == 0){
				lasers[0].enableEmission =true;
				lasers[1].enableEmission =false;
				L =1;
			}else if(L == 1){
				lasers[1].enableEmission =true;
				lasers[0].enableEmission =false;
				L =0;
			}
		for(int i = 0; i<lasers.Length;i++){
			if(target != null){
			lasers[i].transform.LookAt(target.transform);
			}
			}
			nextRot = Time.time + RotRate;

			}
		}
		if(OnDie){
			if(Time.time > nextbomb){
				BombParty();
				nextbomb = bombRate + Time.time;
			}
		}
		if(Time.time > nextMode){
			nextMode = Time.time + ModeRate;
			alfaMode = !alfaMode;
		}
		biglaser.SetActive(false);
	}
	void BetaMode(){
		for(int i = 0; i<lasers.Length;i++){
			lasers[i].enableEmission = false;
		}
		if(betaMode){
		biglaser.SetActive(true);
		}else{
			biglaser.SetActive(false);
		if(Time.time > nextbomb){
			BombParty();
			nextbomb = bombRate + Time.time;
			}
		}
		if(Time.time > nextMode){
			nextMode = Time.time + ModeRate;
			betaMode = !betaMode;
		}
	}
	void BombParty(){

		int bomba =(int) Random.Range(0,3);
		int spawn =(int) Random.Range(0,2);
		Instantiate(Bombs[bomba],spawns[spawn].transform.position,spawns[spawn].transform.rotation);

	}
	void LifeController(){
		if(m !=Mode.Death){
		if(Time.time>nextCure ){
			nextCure = Time.time + CureRate;
			HpAtual+=Recovery;
			if(HpAtual > HpMax){
				HpAtual = HpMax ;
			}
			}
		}
		if(HpAtual < HpMax*0.25f){
			OnDie = true;
		}else{
			OnDie =false;
		}
		if(HpAtual <= 0){
			if (!ThreadOn) {
				StartCoroutine (ThreadDestruction ());
				ThreadOn = true;
				m = Mode.Death;
			}
		}

	}
	void AplyDamage(float dmg){
		if(m != Mode.Begin){
		HpAtual -=dmg;
		}
	}
	IEnumerator  ThreadDestruction ()
	{
		for(int i = 0; i<lasers.Length;i++){
			lasers[i].enableEmission = false;
		}
		biglaser.SetActive(false);

		for (int i = 0; i<SpotsOfExplosion.Length ; i++) {
			Instantiate (explosion, SpotsOfExplosion [i].transform.position, SpotsOfExplosion [i].transform.rotation);
			// new WaitForSeconds(1);
			yield return new WaitForSeconds (0.25f);

		}
		yield return new WaitForSeconds (1.25f);
		allExplosions = true;
	}
}
