using UnityEngine;
using System.Collections;

public class PlayerDamage : MonoBehaviour {
	TextMesh textMesh;
	private int counter;
	private bool newDamage;

	// Use this for initialization
	void Start () {
		textMesh = GetComponent<TextMesh>();
		counter = 0;
		transform.position = new Vector3(-6.71f, -3.45f, 0);
	
	}
	
	// Update is called once per frame
	void Update () {
		if(ElementEffect.Instance.playerDamageChanged){
			newDamage = true;
			Reset();
		}
		
		if(newDamage){
			
			counter += 1;
			
			if(counter <= 17){
				PopUp();
			}
			
			if (counter >= 100){
				Reset();
				newDamage = false;
			 	ElementEffect.Instance.playerDamage= "";
			}
			
		}

		textMesh.text = ElementEffect.Instance.playerDamage;
	
	}
	
	void Reset(){
		counter = 0;
		ElementEffect.Instance.playerDamageChanged = false;
		transform.position = new Vector3(-6.71f, -3.45f, 0);
	}
	
	void PopUp(){
		if(transform.position.y < -2.45f){
			transform.position += new Vector3(0, 0.1f, 0);
		}else{
			transform.position -= new Vector3(0, 0.3f, 0);
		}
		
	}
}
