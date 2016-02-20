using UnityEngine;
using System.Collections;

public class EnemyDamage : MonoBehaviour {
	TextMesh textMesh;
	private int counter;
	private bool newDamage;

	// Use this for initialization
	void Start () {
		textMesh = GetComponent<TextMesh>();
		counter = 0;
		transform.position = new Vector3(4.8f, 3.5f, 0);
	}
	
	// Update is called once per frame
	void Update () {
		if(ElementEffect.Instance.damagechanged){
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
				ElementEffect.Instance.enemyDamage= "";
				newDamage = false;
			}
		}

		textMesh.text = ElementEffect.Instance.enemyDamage;
	}
	
	void Reset(){
		counter = 0;
		ElementEffect.Instance.damagechanged = false;
		transform.position = new Vector3(4.8f, 3.5f, 0);
	}
	
	void PopUp(){
		if(transform.position.y < 4.5f){
			transform.position += new Vector3(0, 0.2f, 0);
		}else{
			transform.position -= new Vector3(0, 0.3f, 0);
		}
		
	}
}
