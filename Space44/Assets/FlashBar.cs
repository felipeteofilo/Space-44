using UnityEngine;
using System.Collections;

public class FlashBar : MonoBehaviour {

	// Use this for initialization
	public void BarChanged(){
		StartCoroutine(FlashPlayer(0.03f));


	}
	IEnumerator FlashPlayer (float intervalTime)
	{
		
		float elapsedTime = 0f;
		float time = Time.deltaTime;
		Color color = new Color(0,0,0); 
		
		Transform childRenderer = null;
		foreach (Transform child in transform) {
			if (child.name == "Fill") {
				childRenderer = child;
				color = childRenderer.renderer.material.color;
				;
			}
		}
		while (elapsedTime < time) {
			if (childRenderer != null) {
				childRenderer.renderer.material.color = new Color (255,255,255);
			}
			elapsedTime += Time.deltaTime;
			yield return new WaitForSeconds (intervalTime);
		}
		if (childRenderer != null) {
			childRenderer.renderer.material.color = color;
		}
	}

}
