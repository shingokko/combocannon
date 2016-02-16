using UnityEngine;
using System.Collections;

public class CriticalHit : MonoBehaviour {

	TextMesh textMesh;
	private int counter;

	// Use this for initialization
	void Start () {
		textMesh = GetComponent<TextMesh>();
	}
	
	// Update is called once per frame
	void Update () {
		if(ElementEffect.Instance.effectchanged){
			counter += 1;
			 if (counter >= 100){
			 	counter = 0;
			 	ElementEffect.Instance.info= "";
			 	ElementEffect.Instance.effectchanged = false;	
			 }
		}

		textMesh.text = ElementEffect.Instance.info;
	}
}
