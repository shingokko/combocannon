using UnityEngine;
using System.Collections;

public class EnemyHealthBar : MonoBehaviour {

	TextMesh textMesh;
	private int damageCounter;
	private int currentHealth;
	private int lastHealth;

	// Use this for initialization
	void Start () {
		textMesh = GetComponent<TextMesh>();
		damageCounter = 0;
		lastHealth = 0;
		currentHealth = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
		if(EnemyHealth.Instance.currentHealth < lastHealth){
			damageCounter += 1;
			currentHealth = lastHealth;
			if(damageCounter % 5 == 0){
				currentHealth -= 1;
				textMesh.text = currentHealth + " / " + EnemyHealth.Instance.maxHealth;
				lastHealth -= 1;
			}
			
		}else{
			textMesh.text = EnemyHealth.Instance.currentHealth + " / " + EnemyHealth.Instance.maxHealth;
			lastHealth = EnemyHealth.Instance.currentHealth;
			damageCounter = 0;
		}
		
		
	}

}
