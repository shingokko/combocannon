using UnityEngine;
using System.Collections;

public class PlayerDamage : MonoBehaviour {
	TextMesh textMesh;
	private int counter;

	// Use this for initialization
	void Start () {
		textMesh = GetComponent<TextMesh>();
		counter = 0;
	
	}
	
	// Update is called once per frame
	void Update () {
		if(ElementEffect.Instance.playerDamageChanged){
			counter += 1;
			 if (counter >= 100){
			 	counter = 0;
			 	ElementEffect.Instance.playerDamage= "";
			 	ElementEffect.Instance.playerDamageChanged = false;	
			 }
		}

		textMesh.text = ElementEffect.Instance.playerDamage;
	
	}
}
