using UnityEngine;
using System.Collections;

public class EnemyDamage : MonoBehaviour {
	TextMesh textMesh;
	private int counter;

	// Use this for initialization
	void Start () {
		textMesh = GetComponent<TextMesh>();
		counter = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if(ElementEffect.Instance.damagechanged){
			counter += 1;
			 if (counter >= 100){
			 	counter = 0;
			 	ElementEffect.Instance.enemyDamage= "";
			 	ElementEffect.Instance.damagechanged = false;	
			 }
		}

		textMesh.text = ElementEffect.Instance.enemyDamage;
	}
}
